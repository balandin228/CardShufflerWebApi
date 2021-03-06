# CardShufflerWebApi
### Несколько слов о проекте
* Платформа: Asp.net MVC with Controllers
* ORM: Entity Framework Core
* Database: MSSqlLocalDb
* Для удобства, подключил Swagger
* Логика работы с базой данных основана на паттерне IRepository
* Для инциализации базы данных в консоли менеджера пакетов прописать: Update-Database

### Времени затрачено
* разработка логики и классов построения колоды и тасования ~ **2 часа**
* разработка модели данных ~ **1 час**
* разработка сервисов управления данными (Infrastructure) ~ **2-3 часа**
* написание нескольких тестов ~ **15-20 минуи**
* настраивание Startup ~ **15-20 минут**
* проблемы со сборкой, msSql, связыванием данных ~ **5-7 часов**
### Итого: **6 часов**  
Если не считать нестандартные и труднодебажащиеся и трекающиеся проблемы

### Я бы мог добавить:
* Авторизацию через Jwt токен
* Обработку ошибок
* Mediatr


### Коментарий к проекту
* Архитектура сервиса получилась достаточно большой, для такого задания, дело в том, что я всегда пытаюсь сделать будущую архитектуру расширяемой и универсальной,
с соблюдением принципов ООП и Solid
* Полное покрытие тестами делать не стал, так как наверное, это не целесообразно. Решил просто показать несколько примеров работы с Unit-тестами
* Очень много коммитов связанных с фиксами миграций и тд. Дело в том, что чаще всего я применял данные архитектурные подходы к NoSql базам данных, а с MSSqlServer **localDb**
вообще до этого не работал
* ~~Остался баг в программе, при инициализации базы данных, почему то, столбцы Rank и Suit меняются местами. Хотя в коде инициализации данных и в скрипте 
миграции все верно. Возможно это как то связано конкретно с MSSql. Я не смог разобраться с этим. Возможно до проверки устраню~~  
**Решил это переносом localDb в другую дериктероию(не понимаю)**
* Обычно вместе с IRepository, я использую ISpecification, но на данный момент, не успел реализовть, так как долго разбирался с выше перечисленными проблемами.
* Нужно было добавить Migrations в .gitignore
