using MudBlazor;

namespace Client;

public static class CustomThemes
{
    public static MudTheme PlatformStandard => new()
    {
        Palette = new PaletteLight
        {
            Primary = Colors.Blue.Darken2,
            PrimaryLighten = Colors.Blue.Darken1,
            PrimaryDarken = Colors.Blue.Darken3,
            Tertiary = "#fed932",
            TertiaryLighten = "#ffdc51",
            TertiaryDarken = "#fbbd00",
        },
        PaletteDark = new PaletteDark
        {
            Primary = Colors.Blue.Darken2,
            PrimaryLighten = Colors.Blue.Darken1,
            PrimaryDarken = Colors.Blue.Darken3,
            Tertiary = "#fed932",
            TertiaryLighten = "#ffdc51",
            TertiaryDarken = "#fbbd00",
        },
        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "0",
            DrawerWidthRight = "300px",
            DrawerWidthLeft = "300px",
            AppbarHeight = "0",

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
            H5 = new H5 { FontWeight = 600 },
            H6 = new H6 { FontWeight = 600 },
            Subtitle1 = new Subtitle1 { FontWeight = 500 },
            Default = new Default { LineHeight = 1 },
        },
        ZIndex = new ZIndex
        {

        },
        
    };

}
