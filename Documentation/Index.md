## ����� �2v10

������� ������������ ��������� ��������� UI-����� 
� �������������� ������ [Selenium.WebDriver](https://www.selenium.dev).

## ��������������

������� ������� ������������ � ��������� ����� ����� �������� 
�� ������ ������������ � �������������� Test Framework.


## ���������

1. ���������� ����������� ������������  �� https://github.com/alex-kukhtin/A2v10.Tests.Browser/releases
2. �������� ����� ������ Visual Studio (C# library .NET Framework 4.6.1).
3. �������� � References ������ �� ���������� `C:\Program Files (x86)\a2v10\Tools\A2v10.Tests.Browser.dll`. 
��� ����� ��� ����, ����� ������� Intellisense ��� ����� XAML-����.
4. �������� ����� Tests. � ���� ����� ����� ������� ���� `Tests.Runner.config`. ������ ����� ������ ����.
__�������� ��������!__ ���� ���� ������ ����� ������������� � ����������� (� �� ��� �������), 
�� ����������� �������� ���� ���� � `.gitignore`, ������ ��� ��� ����� ������ � ������.
5. � ���� ����� ������������� ����� ��� ������������, ������ ������� � �����, � ������� ����� ������������� �����.
6. ������� ������ ����� Tests �������� � ������� ������. �������� `01 ����� �����`. ������������� �������� ����� ����� � ����, ��������� ���������� ������������ ��������� ����� � ����� �� �����.
7. ������� ����� �� ������� ����� �� ���� `C:\Program Files (x86)\a2v10\Tools\A2v10.Tests.Runner.exe`
����������� ������� ������� (Working Directory) �� ����� `{path}\Tests` (`{path}` ��� ����, ��� ����� ������).
8. ����� � ��������� �����. �������� ������ ������ ����.


## ������ .config �����.

��� ����������� ���� ������������ .NET.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="hosts" allowDefinition="Everywhere" type="A2v10.Tests.Browser.HostsSection, A2v10.Tests.Browser"/>
  </configSections>
  <hosts>
    <host name="a2v10.com">
      <source name="������ ����� ������" directory="01 ����� �����" url="https://a2v10.com" login="login_here" password="password_hrere" company=""/>
      <source name="������ ����� ������" directory="02 ��� �����" url="https://a2v10.com" login="login_here" password="password_hrere" company=""/>
    </host>
  </hosts>
</configuration>
```

������ `configSections` ����������� � ��������� �������� ������ `hosts`.

������ `hosts` �������� �������� ������ ��� ���������� ������, ������� �� ����� �����������.

������ ������ `host` ����� ��� � �������� ���� ��� ��������� ������� ������.

������ ����� ������ ����� ���, �������� � ����� � �������, URL ����������, ������� ����� �������������, ��� � ������ ��� ����� �, �������� �������� ������ ���������� 
(����� � ������ multicompany).

## ������ ������ ������

����� ������ ������ ����� ���������� `.feature.xaml`. 

������ ���� ��������� ���� ����������� (Feature), ������� �������� ��������� ��������� (Scenario).

������ �������� ������� �� ������ ��� ���������� ����� (Steps). ��������� ���� (�������� Dialog) 
����� ��������� ����������� ������� ��������� (Scope). ���, ��� ����������� ������ ���� ��������� � 
���� ������� ���������. ������ ������� ��������� ����� ��������� �������� (Actions) 
��� ��������� ��������� (States)

#### ���� (Steps)

* **Navigate**  - ��������� �� �������� url. Url �������� ��������� - *Url*.
* **Dialog**  - ��������� ����� ������� ��������� � ������� ��������. ��� ���� ������ ����� 
���������� � �������. �������� ������� - �������� *Title*, *TestId* (�������� � Xaml).
* **Confirm** - �� �� �����, ��� � ������.
* **Control** - ��������� ����� ������� ��������� � ��������� ���������. ��� ���� ������ - *ElementStep* 
* ��������� � ����� �������� ����������.
* **TreeView** - ��������� ����� ������� ��������� � �������.
* **NewWindow**  - ��������� ����� ������� ��������� � ������� �������� �����. ���� ��� ����� 
������ ����� ���������� �������, ������� ��������� ���-�� � ����� ����.
��� ���� ������ ����� 
���������� � ����� ����. �������� ���� - �������� *Title* � *Url*. ��� ������ �� ������� ���������, 
���� ��������� �������������.
* **DataGrid**  - ��������� ����� ������� ��������� *DataGrid*. ������ ��� ������� ������������� ��������.

#### �������� (Actions)

* **ClickButton** - ������ ������. ������ ����� ������ ������� (������� *Text*) ��� ������� (������� *Icon*).
* **ClickMenuItem**  - ������ ������� ����. ������� ����� ������ ������� (������� *Text*).
* **ClickLink** - ������ ������. ������ �������� ��������� *Url* ��� ������� (������� *Text*).
* **ClickListItem** - ������ ������� ������. ������� �������� ��������� *Header*.
* **ClickTabBarButton** - ������ �� ������ � *TabBar*. �������� ��������� *Text*.
* **ClickAddOn** - ������ ������ AddOn. �������� ������� (������� *Icon*).
* **Escape**  - ������ ������� *Escape*.
* **Enter**  - �������� *Enter* �� ��������.
* **TypeText**  - ������ ����� � ���� ��������. �������� ��������� *Text*.
* **EnterText**  - ������ ����� � ���� �������� � �������� ������� *Enter*. �������� ��������� *Text*.
* **ClickCaret**  - �������� �� "������" ���������.
* **SelectorPane**  - ��������� ����� ������� ��������� � ������� ���������. ��� ���� ������ ����� 
���������� � ���� ������.
* **Select**  - �������� ������� � ������ ���������. �������� ��������� *Text*.
* **WaitForComplete** - ������� ���������� ��������.

#### ��������� (States)

* **Valid**  - ���������, ��� ������� ���������.
* **Invalid**  - ���������, ��� ������� � ��������� ������. ������ ����� ��������� ����� �������� *Message*.
* **EnsureEmpty**  - ���������, ��� ������� ����.
* **EnsureText**  - ���������, ��� ������� �������� �����. . �������� ��������� *Text*.
* **Disabled**  - ���������, ��� ������� ��������.