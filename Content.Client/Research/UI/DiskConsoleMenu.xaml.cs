using Content.Client.UserInterface.Controls;
using Content.Shared.Research;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Research.UI;

[GenerateTypedNameReferences]
public sealed partial class DiskConsoleMenu : FancyWindow
{
    public event Action? OnServerButtonPressed;
    public event Action? OnPrintButtonPressed;
    public event Action? OnPrintRareButtonPressed; // Frontier - Added for mass point use

    public DiskConsoleMenu()
    {
        RobustXamlLoader.Load(this);

        ServerButton.OnPressed += _ => OnServerButtonPressed?.Invoke();
        PrintButton.OnPressed += _ => OnPrintButtonPressed?.Invoke();
        PrintRareButton.OnPressed += _ => OnPrintRareButtonPressed?.Invoke(); // Frontier - Added for mass point use
    }

    public void Update(DiskConsoleBoundUserInterfaceState state)
    {
        PrintButton.Disabled = !state.CanPrint;
        PrintRareButton.Disabled = !state.CanPrintRare; // Frontier - Added for mass point use
        TotalLabel.Text = Loc.GetString("tech-disk-ui-total-label", ("amount", state.ServerPoints));
        //CostLabel.Text = Loc.GetString("tech-disk-ui-cost-label", ("amount", state.PointCost));
        PrintButton.Text = Loc.GetString("tech-disk-ui-print-button", ("amount", state.PointCost)); // Frontier
        PrintRareButton.Text = Loc.GetString("tech-disk-ui-print-rare-button", ("amount", state.PointCostRare)); // Frontier
    }
}

