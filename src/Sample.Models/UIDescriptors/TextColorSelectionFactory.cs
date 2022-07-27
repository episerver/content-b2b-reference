using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.UIDescriptors;

public class TextColorSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new List<SelectItem>
        {
            new SelectItem { Text = "Transparent", Value = "text-transparent" },
            new SelectItem { Text = "Black", Value = "text-black" },
            new SelectItem { Text = "White", Value = "text-white" },
            new SelectItem { Text = "Slate", Value = "text-slate-500" },
            new SelectItem { Text = "Gray", Value = "text-gray-500" },
            new SelectItem { Text = "Zinc", Value = "text-zinc-500" },
            new SelectItem { Text = "Neutral", Value = "text-neutral-500" },
            new SelectItem { Text = "Stone", Value = "text-stone-500" },
            new SelectItem { Text = "Red", Value = "text-red-500" },
            new SelectItem { Text = "Orange", Value = "text-orange-500" },
            new SelectItem { Text = "Amber", Value = "text-amber-500" },
            new SelectItem { Text = "Yellow", Value = "text-yellow-500" },
            new SelectItem { Text = "Lime", Value = "text-lime-500" },
            new SelectItem { Text = "Green", Value = "text-green-500" },
            new SelectItem { Text = "Emerald", Value = "text-emerald-500" },
            new SelectItem { Text = "Teal", Value = "text-teal-500" },
            new SelectItem { Text = "Cyan", Value = "text-cyan-500" },
            new SelectItem { Text = "Sky", Value = "text-sky-500" },
            new SelectItem { Text = "Blue", Value = "text-blue-500" },
            new SelectItem { Text = "Indigo", Value = "text-indigo-500" },
            new SelectItem { Text = "Violet", Value = "text-violet-500" },
            new SelectItem { Text = "Purple", Value = "text-purple-500" },
            new SelectItem { Text = "Fuchsia", Value = "text-fuchsia-500" },
            new SelectItem { Text = "Pink", Value = "text-pink-500" },
            new SelectItem { Text = "Rose", Value = "text-rose-500" },

        };
    }
}
