using PhoneBook;

// Количество выводимых контактов на странице
const int ROWS_IN_PAGE = 2;

var phoneBook = new List<Contact>();

phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

Console.Write("Введите номер страницы: ");

while (true)
{
	char choice = Console.ReadKey().KeyChar;
	Console.Clear();

	if (!char.IsDigit(choice) || choice == '0')
	{
		ShowMessage(ConsoleColor.Red, "Некоректный ввод!");
	}
	else
	{
		var parsed = int.Parse(choice.ToString());
		var set = (parsed * ROWS_IN_PAGE) - ROWS_IN_PAGE;
		var page = phoneBook.Skip(set).Take(ROWS_IN_PAGE)
							.OrderBy(c => c.Name).ThenBy(c => c.LastName);

		if (page.Any())
		{
			foreach (var contact in page)
			{
				Console.WriteLine($"Имя: {contact.LastName} {contact.Name}," +
					$" номер телефона: {contact.PhoneNumber}, E-Mail: {contact.Email}");
			}
		}
		else
		{
			ShowMessage(ConsoleColor.Yellow, "Такой страницы не существует!!");
		}
	}
}

static void ShowMessage(ConsoleColor color, string message)
{
	ConsoleColor currentColor = Console.ForegroundColor;
	Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ForegroundColor = currentColor;
}