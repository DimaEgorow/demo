   M S B A M L   `   `   `  ����B  >WpfApp6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp6.pagesWpfApp6.pages  5          WpfApp6.pages.PartnerPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp6.pages     5        N� Title$%  Список партнеров��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��* �6   �� 5      $��75 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��5q�6;   .+�5      �� -   5         ��Name$ TbSearch��5      $	��300��6(   $��40��64   $��10q�6@   6L   �� 5      -   5         ��Name$ CmbSort��5      $	��200��6(   $��40��64   $��10q�6@   .@�5      �� $<��6Наименование (по возрастанию)��6   �� 5      $6��0Наименование (по убыванию)��6   5      �� 5      -   5        $ 	CmbFilter��5      $	��200��6*   $��40��66   $��10q�6B   .@�5      �� $��Все типы��6   �� 5      $��ЗАО��6   �� 5      $��ООО��6   �� 5      $��ПАО��6   �� 5      $��ОАО��6   5      �� 5      -   5         ��Name$ counts��5      $��-250,50,0,0q�6(   $	��100��6=   $��20��6I   6W   5      �� 5!   
   -   5         ��Name$ LvAgents��5!      $��1��6%   ��5"      �� 5#      .R�5$      �� $ 
Horizontal=�6!   $��5q�6:   $	��800��6b   ��6E   �� *Color+.+�5%      �� $ Vertical=�6%   $��5q�6<   $	��600��6G   .+�5&      �� $ 
Horizontal=�6)   .+�5'   "   �� $ TbTitle��6,   $��20(�6Z   ��6=   �� *TypePartner+6j   �� 5(   "   $��20(�6-   |6?   �� 5)   "   $��20(�6I   ��6,   �� *NamePartner+6Y   5*      �� 5,      $��20(�6B   ��6(   �� *
Director+6R   �� 5-      $��20(�6?   ��6(   �� *Email+6O   �� 5.      $ 
Horizontal=�6)   .+�50   "   �� $��20(�6-   Рейтинг:6E   �� 51   "   $��20(�6D   ��6,   �� *Rating+6T   52      53      �� 54      $��20(�6B   $��Center=�6P   ��6$   �� *DiscountText+6P   55      56      58      �� 5:   
   $ 
Horizontal=�6   $��2��6.   .+�5;      �� -   5         ��Name$ BtnAddAgent��5;      $'��!Добавить партнера��6*   $��
50,26,0,19q�6F   6Z   �� 5<      -   5        $ 
HistoryBtn��5<      $)��#История реализации��6)   $��
50,26,0,19q�6F   6\   �� 5=      -   5        $ CalcBtn��5=      $>��8Калькулятор расчета материала��6&   $��
50,26,0,19q�6N   $	��271��6b   6p   �� 5>      -	   5        $ btnBack��5>      $��20��6&   
�������
���   �$��<��6W   $��	450,0,0,0q�6f   6y   �� 5?      -
   5         ��Name$ sPanel��5?      $ 
Horizontal=�6)   �� 5@      -   5        $ btnNext��5@      $��20��6&   
�������
���   �$��>��6W   $��5,0,0,0q�6f   6w   5A      5B      5C      