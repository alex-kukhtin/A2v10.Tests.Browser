## Тесты А2v10

Система тестирования позволяет выполнять UI-тесты 
с использованием пакета [Selenium.WebDriver](https://www.selenium.dev).

## Предупреждение

Текущая система тестирования в ближайшее время будет заменена 
на пакеты тестирования с использованием Test Framework.


## Установка

1. Установите инструменты тестирования  из https://github.com/alex-kukhtin/A2v10.Tests.Browser/releases
2. Создайте новый проект Visual Studio (C# library .NET Framework 4.6.1).
3. Добавьте в References ссылку на библиотеку `C:\Program Files (x86)\a2v10\Tools\A2v10.Tests.Browser.dll`. 
Она нужна для того, чтобы работал Intellisense при вводе XAML-кода.
4. Создайте папку Tests. В этой папке нужно создать файл `Tests.Runner.config`. Формат файла описан ниже.
__Обратите внимание!__ Если этот проект будет располагаться в репозитории (я на это надеюсь), 
то обязательно добавьте этот файл в `.gitignore`, потому что там будут адреса и пароли.
5. В этом файле настраиваются хосты для тестирования, логины доступа и папки, в которых будут располагаться тесты.
6. Содайте внутри папки Tests подпапку с набором тестов. Например `01 Общие тесты`. Рекомендуется начинать имена папок с цифр, поскольку инструмент тестирования сортирует папки и тесты по имени.
7. 



## Формат .config файла.

Это стандартный файл конфигурации .NET.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="hosts" allowDefinition="Everywhere" type="A2v10.Tests.Browser.HostsSection, A2v10.Tests.Browser"/>
  </configSections>
  <hosts>
    <host name="a2v10.com">
      <source name="Первый набор тестов" directory="01 Общие тесты" url="https://a2v10.com" login="login_here" password="password_hrere" company=""/>
      <source name="Второй набор тестов" directory="02 Еще тесты" url="https://a2v10.com" login="login_here" password="password_hrere" company=""/>
    </host>
  </hosts>
</configuration>
```

Секция `configSections` стандартная и разрешает создание секций `hosts`.

Секция `hosts` включает описание одного или нескольких хостов, которые мы будем тестировать.

Каждая секция host имеет имя и включает один или несколько наборов тестов.

Каждый набор тестов имеет имя, привязку к папке с тестами, URL приложения, которое будет тестироваться, имя и пароль для входа и, возможно компанию внутри приложения 
(нужно в режиме multicompany).

