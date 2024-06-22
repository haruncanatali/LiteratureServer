using System.ComponentModel;

namespace LiteratureServer.Domain.Enums;

public enum Gender
{
    [Description("Kadın")]
    Female = 1,
    [Description("Erkek")]
    Male,
}