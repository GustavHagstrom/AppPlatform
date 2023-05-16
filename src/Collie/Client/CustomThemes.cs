using MudBlazor;

namespace Collie.Client;

public static class CustomThemes
{
    public static MudTheme CollieStandard => new()
    {
        Palette = new PaletteLight
        {
            Primary = Colors.Blue.Darken2,
            PrimaryLighten = Colors.Blue.Darken1,
            PrimaryDarken = Colors.Blue.Darken3,
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Blue.Darken2,
            PrimaryLighten = Colors.Blue.Darken1,
            PrimaryDarken = Colors.Blue.Darken3,
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "0",
            
        },
        PseudoCss = new PseudoCss
        {

        },
        Shadows = new Shadow
        {
            
        },
        Typography = new Typography
        {
            Button = new Button { TextTransform = "none" },
        },
        ZIndex = new ZIndex
        {

        },
    };

}
