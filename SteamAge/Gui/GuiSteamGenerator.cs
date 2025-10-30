using Cairo;

using SteamAge.BEBehaviors;

using Vintagestory.API.Client;

namespace SteamAge.Gui;

public class GuiSteamGenerator : GuiDialog
{
    public override string ToggleKeyCombinationCode => null;

    BEBehaviorSteamGenerator generator;
    BEBehaviorSteamContainer container;
    public GuiSteamGenerator(ICoreClientAPI capi, BEBehaviorSteamGenerator steamGenerator, BEBehaviorSteamContainer steamContainer) : base(capi)
    {
        generator = steamGenerator;
        container = steamContainer;
        // Auto-sized dialog at the center of the screen
        ElementBounds dialogBounds = ElementStdBounds.AutosizedMainDialog.WithAlignment(EnumDialogArea.CenterMiddle);

        // Just a simple 300x300 pixel box
        ElementBounds textBounds = ElementBounds.Fixed(0, 40, 300, 500);
        ElementBounds liquidBounds = ElementBounds.Fixed(100, 30, 40, 200);

        // Background boundaries. Again, just make it fit it's child elements, then add the text as a child element
        ElementBounds bgBounds = ElementBounds.Fill.WithFixedPadding(GuiStyle.ElementToDialogPadding);
        bgBounds.BothSizing = ElementSizing.FitToChildren;
        bgBounds.WithChildren(textBounds);
        SingleComposer = capi.Gui.CreateCompo("myAwesomeDialog", dialogBounds)
            .AddShadedDialogBG(bgBounds)
            .AddDialogTitleBar("Steam Generator", () => { TryClose(); })
            .AddStaticText(steamGenerator.Water.ToString(), CairoFont.WhiteDetailText(), textBounds)
            .AddDynamicCustomDraw(liquidBounds, new DrawDelegateWithBounds(fullnessMeterDraw), "liquidBar")
            .Compose()
        ;
    }

    private void fullnessMeterDraw(Context ctx, ImageSurface surface, ElementBounds currentBounds)
    {
        double capacity = 11.0;
        double currentLevel = currentBounds.InnerHeight;

        double waterLevel = 3.0 / capacity;
        currentLevel -= waterLevel * currentBounds.InnerHeight;
        ctx.SetSourceColor(new Color(0.0, 0.0, 1.0));
        ctx.Rectangle(0.0, currentLevel, currentBounds.InnerWidth, currentBounds.InnerHeight * waterLevel);
        ctx.Fill();

        double steamLevel = 0.0 / capacity;
        currentLevel -= steamLevel * currentBounds.InnerHeight;
        ctx.SetSourceColor(new Color(0.0, 1.0, 0.0));
        ctx.Rectangle(0.0, currentLevel, currentBounds.InnerWidth, currentBounds.InnerHeight * steamLevel);
        ctx.Fill();

        double airLevel = 1.0 / capacity;
        currentLevel -= airLevel * currentBounds.InnerHeight;
        ctx.SetSourceColor(new Color(1.0, 0.0, 0.0));
        ctx.Rectangle(0.0, currentLevel, currentBounds.InnerWidth, currentBounds.InnerHeight * airLevel);
        ctx.Fill();
    }
}
