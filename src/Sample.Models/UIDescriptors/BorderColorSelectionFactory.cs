using System;
using EPiServer.Shell.ObjectEditing;

namespace Sample.Models.UIDescriptors;

public class BorderColorSelectionFactory : ISelectionFactory
{
    public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
    {
        return new List<SelectItem>
        {
            new SelectItem { Text = "Transparent", Value = "border-transparent" },
            new SelectItem { Text = "Black", Value = "border-black" },
            new SelectItem { Text = "White", Value = "border-white" },
            new SelectItem { Text = "Slate", Value = "border-slate-500" },
            new SelectItem { Text = "Gray", Value = "border-gray-500" },
            new SelectItem { Text = "Zinc", Value = "border-zinc-500" },
            new SelectItem { Text = "Neutral", Value = "border-neutral-500" },
            new SelectItem { Text = "Stone", Value = "border-stone-500" },
            new SelectItem { Text = "Red", Value = "border-red-500" },
            new SelectItem { Text = "Orange", Value = "border-orange-500" },
            new SelectItem { Text = "Amber", Value = "border-amber-500" },
            new SelectItem { Text = "Yellow", Value = "border-yellow-500" },
            new SelectItem { Text = "Lime", Value = "border-lime-500" },
            new SelectItem { Text = "Green", Value = "border-green-500" },
            new SelectItem { Text = "Emerald", Value = "border-emerald-500" },
            new SelectItem { Text = "Teal", Value = "border-teal-500" },
            new SelectItem { Text = "Cyan", Value = "border-cyan-500" },
            new SelectItem { Text = "Sky", Value = "border-sky-500" },
            new SelectItem { Text = "Blue", Value = "border-blue-500" },
            new SelectItem { Text = "Indigo", Value = "border-indigo-500" },
            new SelectItem { Text = "Violet", Value = "border-violet-500" },
            new SelectItem { Text = "Purple", Value = "border-purple-500" },
            new SelectItem { Text = "Fuchsia", Value = "border-fuchsia-500" },
            new SelectItem { Text = "Pink", Value = "border-pink-500" },
            new SelectItem { Text = "Rose", Value = "border-rose-500" },

        };
    }
}