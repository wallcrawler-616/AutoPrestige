   M S B A M L   `   `   `  ????M  IAutoPrestigeArenda, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AutoPrestigeArendaAutoPrestigeArenda  5   	   m iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35?mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting 5   	   #    AutoPrestigeArenda.ManagerBuy   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AutoPrestigeArenda     5   	   }dvcmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :
extensions)using:Microsoft.Toolkit.Uwp.UI.Extensions  5	   	     ? Title$  AutoPrestige??5   	   $	??750??6   $
??1000??6+   $	??750??68   $
??1000??6H   .??5      ? .+?5   
   ?? -   5         ??Name$ LogogImg??5      $??/Images/Logo.png??6"   $
??Left=?6<   $	??Top=?6W   $??80??6o   $??50??6z   ?? 5   
   -   5         ??Name$ Title??5      $??0??6   $D??>Менеджер по работе с автомобилями??6,   $??Center=?6X   $	??Top=?6u   $
??Bold"?6?   $??0,15,0,0q?6?   $??1??6?   ?? 5   
   $??	0,50,0,50q?6      MaterialDesignTabControl#??[  6(   .@?5      ?? $)??#Список автомобилей??6   .??5      ?  ? RowDefinitions 5      ?? 5      6*   ?? 5      6*   ?? 5      6*    ? ColumnDefinitions 5      ?? 5      6-   ?? 5      6-   ?? 5      6-   .+?5      ?? $??Поиск 🔎??6   $
??Left=?6/   $	??Top=?6J   $??10,8,0,0q?6b   ?? 5      -   5         ??Name$ SearchTB??5      $	??Top=?60   $
??Left=?6H   $	??218??6c   $??25??6o   $??	10,39,0,0q?6{    ? ToolTip$ 
Поиск??6?   &   System.Windows.Controls.DataGrid  5      -   5          Name$
 Cars??5         
IsReadOnly . 	   AlternatingRowBackground
	 ?????
   AutoGenerateColumns
 .  $??Stretch=?6?   $??Stretch=?6?   $??	10,69,0,0q?6?   $??2??6  $??2??6)  ??6?   ??    Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$% Номер автомобиля??61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   ?? *Number+  5"      $ Модель??61    6A   ?? *Model+  5#      $ Привод??61    6A   ?? *
Drive_unit+  5$      $ Компьютер??61    6D   ?? *Onboard_computer+  5%      $ Корбка??61    6A   ?? *Transmission+  5&      $ Статус??61    6A   ?? *Status+5(      ? 5)      $??0??6   $??2??6+   $??2??68   $??2q?6L   $??Stretch=?6W   .+?5*      ?? -   5         ??Name$ DictionaryCB??5*   #   $
??Left=?6:   $	??Top=?6U   $??	81,80,0,0q?6m   $	??234??6?   ?? 5+      -   5         ??Name$ FilterBT??5+   !   $
??Left=?64   $	??Top=?6O   $??
81,113,0,0q?6g   $	??234??6?   $$??Отфильтровать ⧩??6?   ?? 5,      $??Фильтры??6    $??26??62   $	??Top=?6>   $
??Left=?6V   $??	81,45,0,0q?6q   $??70??6?   ?? 5-      -   5        $ Filter??5-   #    ?? 
IsEditable . $??
322,80,0,0q?6F   $
??Left=?6[   $	??Top=?6v   $	??235??6?   ??6?   ?? 6?   ?? 5.      -   5        $ CanelFilter??5.   !   $??Сброс 🚫??67   $
??Left=?6K   $	??Top=?6f   $??322,113,0,0q?6~   $	??235??6?   5/      ? 50      $??1??6   $??2??6)   $??0q?69   $??2??6D   $??Stretch=?6U   .+?51      ?? $??
Номер??6    $
??Left=?60   $	??Top=?6K   $??
10,171,0,0q?6c   ?? 52      -	   5        $ NumberTB??52   "   $??Stretch=?66   $	??Top=?6T   $??159,171,20,0q?6l    ?? 	MaxLength$ 9??6?   6?   ?? 53      $??Модель??6    $
??Left=?61   $	??Top=?6L   $??
10,208,0,0q?6d   ?? 54      -
   5        $ ModelCB??54   #   $??Stretch=?64   $	??Top=?6R   $??159,208,20,0q?6j   ??6?   ?? ?? 55      -   5        $ DriverUnitTB??55   #    . $??Stretch=?6d   $	??Top=?6?   $??159,242,20,0q?6?   ??69   ?? 6?   ?? 56      -   5        $ 
ComputerTB??56   #   $??Stretch=?68   $	??Top=?6V   $??159,277,20,0q?6n   .@?57      ?? .??6+   
Есть61   ?? 58      .??6+   Нет60   59      ?? 5:      -   5        $ TransmissionTB??5:   #   $??Stretch=?6S   $	??Top=?6q   $??159,312,20,0q?6?   ??6;   ?? 6?   ?? 5;      $??Привод??6!   $
??Left=?62   $	??Top=?6M   $??
10,242,0,0q?6e   ?? 5<      $)??#Бортовой компьютер??6    $
??Left=?6=   $	??Top=?6X   $??
10,275,0,0q?6p   ?? 5=      $#??Коробка передач??6!   $
??Left=?6;   $	??Top=?6V   $??
10,309,0,0q?6n   ?? 5?      -   5        $ Status??5?   #   $??Stretch=?64   $	??Top=?6R   $??159,343,20,0q?6j   ?? 5@      $??Статус??6    $
??Left=?61   $	??Top=?6L   $??
10,339,0,0q?6d   ?? 5B      -   5        $ InsertBT??5B   !   $??Добавить ✓??63   $??Center=?6I   $	??Top=?6f   $??0,47,0,0q?6?   $	??200??6?   ?? 5C      -   5        $ DeleteBT??5C   !   $??Списание 🗑??63   $??Center=?6J   $	??Top=?6g   $??	0,119,0,0q?6   $	??200??6?   ?? 5D      -   5        $ UpdateBT??5D   !   $??Обновить ✎??63   $	??Top=?6H   $??Center=?6`   $??0,82,0,0q?6}   $	??200??6?   5E      ?? 5F      -   5        $ Photo??5F      $??Stretch=?6+   $??Stretch=?6I   $??
10,10,10,0q?6x   $??2??6?   ??6e   ?? 6?   5H      5I      ?? 5J      $??Модели??6   .??5K      ?  5L      ?? 5M      ?? 5N      ?? 5O       5Q      ?? 5R      ?? 5S      ?? 5T      .+?5V      ?? -   5        $ 
ModelPhoto??5V      $??Stretch=?60   $??Stretch=?6N   $??
10,10,10,0q?6}   $??2??6?   ??6j   ?? 6?     5X      -   5        $ ModelsTabel??5X       . 
	 ?????
 .  $??Stretch=?6?   $??Stretch=?6?   $??	10,69,0,0q?6?   $??2??6%  $??2??69  ??6?   ??  5Y        5[      $ Модель??61    6A   ?? *Model+  5\      $  Производитель??61    6H   ?? *Brand+  5]      $ 
Класс??61    6@   ?? *Class+  5^      $ Количество??61    6E   ?? *Count+  5_      $&  Цена в сутки (Руб.)??61    6N   ?? *Price+5a      ? 5c      $??1??6   $??2??6(   $??0q?68   $??3??6C   $??Stretch=?6T   .+?5d      ?? -   5        $ InsertModelBT??5d   !   $??Italic)?68   $??Center=?6L   $	??Top=?6i   $??Добавить ✓??6?   $??0,10,0,0q?6?   $	??235??6?   6?   ?? 5e      -   5        $ UpdateModelBT??5e   !   $??Обновить ✎??68   $??Center=?6N   $	??Top=?6k   $??0,45,0,0q?6?   $	??235??6?   6?   ?? 5f      -   5        $ DeleteModelBT??5f   !   $??Удалить🗑??68   $	??Top=?6L   $??Center=?6d   $??0,82,0,0q?6?   $	??235??6?   6?   ?? 5g      $??
Класс??6!   $
??Left=?61   $	??Top=?6L   $??
10,194,0,0q?6d   ?? 5h      $??
Бренд??6!   $
??Left=?61   $	??Top=?6L   $??
10,162,0,0q?6d   ?? 5i      $??Модель??6!   $
??Left=?62   $	??Top=?6M   $??
10,133,0,0q?6e   ?? 5j      -   5        $ ClassTB??5j   #    . $??22??6^   $	??140??6j   $??Stretch=?6v   $	??Top=?6?   $??154,196,0,0q?6?   ??64   ?? 6?   ?? 5k      -   5        $ BrandTB??5k   #    . $??22??6^   $	??140??6j   $??Stretch=?6w   $	??Top=?6?   $??154,167,0,0q?6?   ??64   ?? 6?   ?? 5l      -   5        $ ModelTB??5l   "   $??22??63   $	??140??6?   $??Stretch=?6L   $	??Top=?6j   $??172,135,18,0q?6?   ?? 5m      $??Количество??6    $
??Left=?65   $	??Top=?6P   $??
10,228,0,0q?6h   ?? 5n      -   5        $ CountTB??5n   "   $	??140??63   $??25??6?   $??Stretch=?6K   $	??Top=?6i   $??154,228,0,0q?6?   $ 10??6?   6?   ?? 5o      $??Цена (Руб.)??6    $
??Left=?66   $	??Top=?6Q   $??
10,263,0,0q?6i   ?? 5p      -   5        $ PriceTB??5p   "   $	??140??63   $??25??6?   $??Stretch=?6K   $	??Top=?6i   $??172,263,18,0q?6?   $ 10??6?   6?   ?? 5q      -   5        $ 
AddPicture??5q   !   $??Обзор 📷??65   $??Center=?6H   $	??Top=?6e   $??50,311,50,0q?6}   $	??230??6?   ?? 5r      -   5        $ 	PictureTB??5r   "   $??Center=?65   $	??Top=?6R   $??50,348,50,0q?6j   $	??230??6?    ?? 
IsReadOnly . 6?   5s      ?? 5t      $??
Поиск??6   $
??Left=?6,   $	??Top=?6G   $??10,8,0,0q?6_   $??50??6q   ?? 5u      -   5        $ SearchModelTB??5u      $	??Top=?65   $
??Left=?6M   $	??218??6h   $??25??6t   $??	10,39,0,0q?6?   $ 
Поиск??6?   ? 5v      $??0??6   $??2??6+   $??2??68   $??2q?6L   $??Stretch=?6W   .+?5w      ?? -    5        $ ModelsDictionaryCB??5w   #   $
??Left=?6@   $	??Top=?6[   $??	81,80,0,0q?6s   $	??234??6?   ?? 5x      -!   5        $ ModelsFilterBT??5x   !   $
??Left=?6:   $	??Top=?6U   $??
81,113,0,0q?6m   $	??234??6?   $$??Отфильтровать ⧩??6?   6?   ?? 5y      $??Фильтры??6    $??26??62   $	??Top=?6>   $
??Left=?6V   $??	81,45,0,0q?6q   $??70??6?   ?? 5z      -"   5        $ ModelsFilter??5z   #    . $??
322,80,0,0q?6L   $
??Left=?6a   $	??Top=?6|   $	??235??6?   ??6?   ?? 6?   ?? 5{      -#   5        $ ModelsCanelFilter??5{   !   $??Сброс 🚫??6=   $
??Left=?6Q   $	??Top=?6l   $??322,113,0,0q?6?   $	??235??6?   6?   5|      5}      5~      5      ?? 5?   
   -$   5        $
 Exit??5?      $
??Left=?6   $??Bottom=?6:   $ 
Выход??6k   $??	10,0,0,10q?6{   .??5?      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ExitToApp=?6&   $
??Auto??67   $
??auto??6D   5?      5?      5?      