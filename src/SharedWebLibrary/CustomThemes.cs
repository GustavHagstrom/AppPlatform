using MudBlazor;

namespace SharedWasmLibrary;

public static class CustomThemes
{
    public static MudTheme PlatformStandard => new()
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
            DrawerWidthRight = "300px",
            DrawerWidthLeft = "300px",

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
        },
        ZIndex = new ZIndex
        {

        },
    };

}
