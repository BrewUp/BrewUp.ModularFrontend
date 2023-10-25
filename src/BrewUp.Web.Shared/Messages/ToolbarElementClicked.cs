using BrewUp.Web.Shared.Enums;

namespace BrewUp.Web.Shared.Messages;

public record ToolbarElementClicked(ToolbarElement ToolbarElement, ModuleNames ModuleName);