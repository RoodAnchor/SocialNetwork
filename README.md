# SocialNetwork
 Репо для 19.5.1

## Задача
 Добавить логику добавления в друзья на уровень PLL и BLL. Процесс добавления пользователя в друзья должен быть следующим:

 1. Пользователь вводит почтовый адрес друга.
 2. Если почтовый адрес существует, то выполняем добавление.
 3. Если почтового адреса не существует, то выбрасываем исключение UserNotFoundException.
 
## Реализация
 Архитектура: 
	3-уровневая (Data Access, Business Logic, Presentation). Каждый уровень в отдельном проекте.  
 На уровне бизнес логики создан класс FriendService которые содержит методы для добавления, удаления и листинга друзей. Так же добавлена модель Friend, содержащая поля Id, UserId и FriendEmail.  
 Основная логика представления функционала работы с друзьями реализована 5 вьюшками:  
 1. FreindsView - основное представление с листингом друзей и пунктами меню для добавления/удаления друзей
 2. FriendsListView - листинг друзей
 3. FriendsMenuView - пункты меню работы с друзьями
 4. AddFriendView - добавление друга
 5. RemoveFriendView - удаление друга

 Написаны юнит тесты для некоторых методов класса UserService. Использовался XUnit.