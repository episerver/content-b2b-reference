using EPiServer.DataAnnotations;
using System;

namespace Sample.Models.Settings;

[AttributeUsage(validOn: AttributeTargets.Class)]
public sealed class SettingsContentTypeAttribute : ContentTypeAttribute
{
    public string SettingsName { get; set; }
}