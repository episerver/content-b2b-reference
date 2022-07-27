using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.UIDescriptors;

public class BgColorSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new List<SelectItem>
        {
            new SelectItem { Text = "Transparent", Value = "bg-transparent" },
            new SelectItem { Text = "Black", Value = "bg-black" },
            new SelectItem { Text = "White", Value = "bg-white" },
            new SelectItem { Text = "Slate", Value = "bg-slate-500" },
            new SelectItem { Text = "Gray", Value = "bg-gray-500" },
            new SelectItem { Text = "Zinc", Value = "bg-zinc-500" },
            new SelectItem { Text = "Neutral", Value = "bg-neutral-500" },
            new SelectItem { Text = "Stone", Value = "bg-stone-500" },
            new SelectItem { Text = "Red", Value = "bg-red-500" },
            new SelectItem { Text = "Orange", Value = "bg-orange-500" },
            new SelectItem { Text = "Amber", Value = "bg-amber-500" },
            new SelectItem { Text = "Yellow", Value = "bg-yellow-500" },
            new SelectItem { Text = "Lime", Value = "bg-lime-500" },
            new SelectItem { Text = "Green", Value = "bg-green-500" },
            new SelectItem { Text = "Emerald", Value = "bg-emerald-500" },
            new SelectItem { Text = "Teal", Value = "bg-teal-500" },
            new SelectItem { Text = "Cyan", Value = "bg-cyan-500" },
            new SelectItem { Text = "Sky", Value = "bg-sky-500" },
            new SelectItem { Text = "Blue", Value = "bg-blue-500" },
            new SelectItem { Text = "Indigo", Value = "bg-indigo-500" },
            new SelectItem { Text = "Violet", Value = "bg-violet-500" },
            new SelectItem { Text = "Purple", Value = "bg-purple-500" },
            new SelectItem { Text = "Fuchsia", Value = "bg-fuchsia-500" },
            new SelectItem { Text = "Pink", Value = "bg-pink-500" },
            new SelectItem { Text = "Rose", Value = "bg-rose-500" },
            
        };
    }
}