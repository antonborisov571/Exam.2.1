using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Player : IEntity
{
    [DisplayName("Имя игрока")]
    public string Name { get; set; }

	[Range(1, 50, ErrorMessage = "Количество хитпоинтов должно быть от 1 до 50")]
    [DisplayName("Хитпоинты")]
    public int HitPoints { get; set; }

	[Range(-5, 5, ErrorMessage = "Модификатор атаки должен быть от -5 до 5")]
    [DisplayName("Модификатор атаки")]
    public int AttackModifier { get; set; }

	[Range(1, 2, ErrorMessage = "Количество атак должно быть от 1 до 2")]
    [DisplayName("Количество атак")]
    public int AttackPerRound { get; set; }

	[RegularExpression(@"\d+d\d+", ErrorMessage = "Введите правильный урон")]
    [DisplayName("Урон")]
    public string Damage { get; set; }

	[Range(-5, 5, ErrorMessage = "Модификатор урона должен быть от -5 до 5")]
    [DisplayName("Модификатор урона")]
    public int DamageModifier { get; set; }

	[Range(1, 16, ErrorMessage = "Класс доспеха должен быть от 1 до 16")]
    [DisplayName("Класс доспеха")]
    public int ArmorClass { get; set; }
}
