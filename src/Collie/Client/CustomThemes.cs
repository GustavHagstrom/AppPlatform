using MudBlazor;

namespace Collie.Client;

public static class CustomThemes
{
    public static MudTheme CollieStandard => new MudTheme
    {
        Palette = new PaletteLight
        {
            //Primary = Colors.Blue.Darken1,
            //PrimaryLighten = Colors.Blue.Lighten1,
            //PrimaryDarken = Colors.Blue.Darken2,
            Primary = Colors.Blue.Darken2,
            PrimaryLighten = Colors.Blue.Darken1,
            PrimaryDarken = Colors.Blue.Darken3,
        },
        PaletteDark = new PaletteDark
        {

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
