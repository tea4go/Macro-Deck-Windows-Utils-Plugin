using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SuchByte.MacroDeck.GUI.CustomControls;

/// <summary>
/// 圆角 NumericUpDown，与 RoundedComboBox / RoundedTextBox 视觉风格一致。
/// 内嵌原生 NumericUpDown，外层 UserControl 负责绘制圆角和承载图标，
/// 高度跟随字体自动重算，避免不同字号下与同行其他控件错位。
/// </summary>
[DefaultEvent(nameof(ValueChanged))]
[DefaultProperty(nameof(Value))]
[DefaultBindingProperty(nameof(Value))]
public partial class RoundedNumericUpDown : UserControl
{
    private int borderRadius = 0;
    private Image icon;

    public event EventHandler ValueChanged;

    public Image Icon
    {
        get => icon;
        set
        {
            icon = value;
            Padding = icon == null ? new Padding(0, 0, 0, 0) : new Padding(numericUpDown1.Height + 3, 0, 0, 0);
            Invalidate();
        }
    }

    public new bool Enabled
    {
        get => numericUpDown1.Enabled;
        set => numericUpDown1.Enabled = value;
    }

    [Category("Behavior")]
    [Bindable(true)]
    public decimal Value
    {
        get => numericUpDown1.Value;
        set
        {
            if (value < numericUpDown1.Minimum)
            {
                value = numericUpDown1.Minimum;
            }
            else if (value > numericUpDown1.Maximum)
            {
                value = numericUpDown1.Maximum;
            }

            numericUpDown1.Value = value;
        }
    }

    [Category("Behavior")]
    [DefaultValue(typeof(decimal), "0")]
    public decimal Minimum
    {
        get => numericUpDown1.Minimum;
        set => numericUpDown1.Minimum = value;
    }

    [Category("Behavior")]
    [DefaultValue(typeof(decimal), "100")]
    public decimal Maximum
    {
        get => numericUpDown1.Maximum;
        set => numericUpDown1.Maximum = value;
    }

    [Category("Behavior")]
    [DefaultValue(typeof(decimal), "1")]
    public decimal Increment
    {
        get => numericUpDown1.Increment;
        set => numericUpDown1.Increment = value;
    }

    [Category("Behavior")]
    [DefaultValue(0)]
    public int DecimalPlaces
    {
        get => numericUpDown1.DecimalPlaces;
        set => numericUpDown1.DecimalPlaces = value;
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool ThousandsSeparator
    {
        get => numericUpDown1.ThousandsSeparator;
        set => numericUpDown1.ThousandsSeparator = value;
    }

    [Category("Behavior")]
    [DefaultValue(false)]
    public bool Hexadecimal
    {
        get => numericUpDown1.Hexadecimal;
        set => numericUpDown1.Hexadecimal = value;
    }

    [Category("Appearance")]
    [DefaultValue(HorizontalAlignment.Left)]
    public HorizontalAlignment TextAlignment
    {
        get => numericUpDown1.TextAlign;
        set => numericUpDown1.TextAlign = value;
    }

    [Category("Appearance")]
    [Description("外层圆角半径，0 表示直角。")]
    [DefaultValue(0)]
    public int BorderRadius
    {
        get => borderRadius;
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    public override Color BackColor
    {
        get => base.BackColor;
        set
        {
            base.BackColor = value;
            numericUpDown1.BackColor = value;
        }
    }

    public override Color ForeColor
    {
        get => base.ForeColor;
        set
        {
            base.ForeColor = value;
            numericUpDown1.ForeColor = value;
        }
    }

    public override Font Font
    {
        get => base.Font;
        set
        {
            base.Font = value;
            numericUpDown1.Font = value;
            UpdateControlHeight();
        }
    }

    public RoundedNumericUpDown()
    {
        InitializeComponent();
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        DoubleBuffered = true;
    }

    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        var curveSize = radius * 2F;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();
        return path;
    }

    private void UpdateControlHeight()
    {
        // NumericUpDown 自身高度由字体决定（Win32 限制），按当前字体测一次文本高度，
        // 再加上上下边距让外层包裹起来。
        var textHeight = TextRenderer.MeasureText("0", Font).Height;
        numericUpDown1.Height = textHeight + 4;
        Height = numericUpDown1.Height + Padding.Top + Padding.Bottom + 8;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (DesignMode)
        {
            UpdateControlHeight();
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        UpdateControlHeight();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var graph = e.Graphics;

        if (borderRadius > 1)
        {
            var rectBorderSmooth = ClientRectangle;
            var rectIcon = new Rectangle(ClientRectangle.X + 3,
                ClientRectangle.Y + ClientRectangle.Height / 2 - numericUpDown1.Height / 2,
                numericUpDown1.Height,
                numericUpDown1.Height);

            var smoothSize = 2;

            using var pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius);
            using var penBorderSmooth = new Pen(Parent.BackColor, smoothSize);
            Region = new Region(pathBorderSmooth);
            if (icon != null)
            {
                graph.DrawImage(icon, rectIcon);
            }

            graph.SmoothingMode = SmoothingMode.AntiAlias;
            graph.DrawPath(penBorderSmooth, pathBorderSmooth);
        }
        else
        {
            Region = new Region(ClientRectangle);
        }
    }

    private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        ValueChanged?.Invoke(this, EventArgs.Empty);
    }

    private void NumericUpDown1_Enter(object sender, EventArgs e)
    {
        OnEnter(e);
    }

    private void NumericUpDown1_GotFocus(object sender, EventArgs e)
    {
        OnGotFocus(e);
    }

    private void NumericUpDown1_LostFocus(object sender, EventArgs e)
    {
        OnLostFocus(e);
    }

    private void NumericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
    {
        OnKeyPress(e);
    }

    private void NumericUpDown1_Click(object sender, EventArgs e)
    {
        OnClick(e);
    }
}
