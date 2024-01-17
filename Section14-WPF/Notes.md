- Install - .NET desktop Development
- Structure
    - MainWindow.xaml
        - MainWindow.xaml.cs (c# file that’s related to the windows)
    - App.xaml
        - App.xaml.cs (c# file that’s acting like a static void main function)

### Related to Window Development

- GUI Element DIY (Develop from the Window directly)
    - Ctrl + Alt + X (ToolBox) - drag elements to the window (XAML will be updated at the same time)
    - Create a grid with columns and rows
        
        ```csharp
        <Grid>
        
        	<Grid.ColumnDefinitions>
        		<ColumnDefinition Width="100" />
        		<ColumnDefinition Width="200" />
        		<ColumnDefinition Width="300" />
        	</Grid.ColumnDefinitions>
        
        	<Grid.RowDefinitions>
        		<RowDefinition Height="50" />
        		<RowDefinition Height="100" />
        		<RowDefinition Height="200" />
        	</Grid.RowDefinitions>
        </Grid>
        ```
        
        - Fixed, Auto, and Relative sizing
            
            ```csharp
            // AUTO - AUTO
            <Grid.ColumnDefinitions>
                <ColumnDefinition  Width="100" />
                <ColumnDefinition  Width="Auto" />
                <ColumnDefinition  Width="300" />
            </Grid.ColumnDefinitions>
            
            // Relative - *
            <Grid.ColumnDefinitions>
                <ColumnDefinition  Width="100" />
                <ColumnDefinition  Width="*" />
                <ColumnDefinition  Width="300" />
            </Grid.ColumnDefinitions>
            ```
            
        - Perfect Grid - Use “*” for all columns and rows
    - Column span and row span
        
        ```csharp
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="10"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="10"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="10"></ColumnDefinition>
            </Grid.ColumnDefinitions>
        
            <Grid.RowDefinitions>
                <RowDefinition Height="10"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="50"/>
                <RowDefinition Height="10"/>
            </Grid.RowDefinitions>
            <Label Grid.Column="2" Grid.Row ="1" Content="Title of App"/>
            <Label Grid.Column="2" Grid.Row ="2" Grid.ColumnSpan="3" Content="Sample Text"/>
            <Button Grid.Column="2" Grid.Row ="3" Content="A" />
            <Button Grid.Column="4" Grid.Row ="3" Content="B" />
        </Grid>
        ```
        
- Create GUI elements with C#
    
    ```csharp
    // xaml file
    <Window x:Class="WPFChallenge.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WPFChallenge"
            mc:Ignorable="d"
            Title="MainWindow" Height="450" Width="800">
        <Grid **x:Name="myGrid"**>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="10"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="10"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="*"></ColumnDefinition>
                <ColumnDefinition Width="10"></ColumnDefinition>
            </Grid.ColumnDefinitions>
    
            <Grid.RowDefinitions>
                <RowDefinition Height="10"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="50"/>
                <RowDefinition Height="10"/>
            </Grid.RowDefinitions>
            <Label Grid.Column="2" Grid.Row ="1" Content="Title of App"/>
            <Label Grid.Column="2" Grid.Row ="2" Content="Sample Text"/>
            <Button Grid.Column="2" Grid.Row ="3" Content="A" />
            <Button Grid.Column="4" Grid.Row ="3" Content="B" />
        </Grid>
    </Window>
    
    // C# FILE
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WPFChallenge
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Button myButton = new Button();
                myButton.Content = "C# Button";
    
                Grid.SetRow(myButton, 3);
                Grid.SetColumn(myButton, 4);
    
                Grid myGrid = (Grid) FindName("myGrid");
                myGrid.Children.Add(myButton);
            }
        }
    }
    ```
    

### Button click and event handlers

```csharp
// WITHIN WINDOW XAML
<Button Grid.Column="2" Grid.Row ="3" Content="A" FontSize="40" Click="Button_Click"/>

// WITHIN THE WINDOW.XAML.CS FILE
private void Button_Click(object sender, RoutedEventArgs e)
{
	MessageBox.Show("Hello World");
}
```

### Content Control & User Control

- Steps
    - Project → Add a new item
    - Search for Control & Create a new LoginView(for example)
    - This process helps create a new window view
    - From MainWindow.xaml.cs file, assign it to our mainContent
        
        ```csharp
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
        				// MainContent is the view name stored 
                MainContent.Content = new LoginView();
            }
        }
        
        // XAML FILE
        <Window x:Class="WpfLogin.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:local="clr-namespace:WpfLogin"
                mc:Ignorable="d"
                Title="MainWindow" Height="450" Width="800">
            <Grid>
                <ContentControl x:Name="MainContent" />
            </Grid>
        </Window>
        ```
        
- Add a trigger to update content
    
    ```csharp
    // XAML
    <Button Click="LoginButton_Clicked" Grid.Column="1" Grid.Row="3">Login</Button>
    
    // CS FILE
    private void LoginButton_Clicked(object sender, RoutedEventArgs e)
    {
        Window window = Window.GetWindow(this);
        window.Content = new InvoiceView();
    }
    ```
    

### Data Binding

- One-way Data Binding - Showing the data on the screen, cannot read data user entered
    
    ```csharp
    <Window x:Class="DataBinding.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:DataBinding"
            mc:Ignorable="d"
            Title="Data Binding" Height="150" Width="265">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height = "10" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "10" />
                <RowDefinition Height = "*" />
                <RowDefinition Height = "10" />
            </Grid.RowDefinitions>
    
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width = "10" />
                <ColumnDefinition Width = "Auto" />
                <ColumnDefinition Width = "*" />
                <ColumnDefinition Width = "10" />
    
            </Grid.ColumnDefinitions>
    
            <Label Grid.Row="1" Grid.Column="1" Margin="2" Content="Name"/>
    
            **<TextBox Text="{Binding Name, Mode=OneWay}" Grid.Row="1" Grid.Column="2" Margin="2" />**
    
            <Label Content="Age" Margin="2" Grid.Column="1" Grid.Row="2" />
    
            **<TextBox Text="{Binding Age, Mode=OneWay}" Grid.Column="2" Grid.Row="2" Margin="2"/>**
    
            <Button Grid.Column="1" Grid.Row="4" Grid.ColumnSpan="2"  Content="Info" Click="Button_Click" />
        </Grid>
    </Window>
    ```
    
- Two-way Data Binding - Default data from c# file, data can be updated through UI.
    
    ```csharp
    <Window x:Class="DataBinding.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:DataBinding"
            mc:Ignorable="d"
            Title="Data Binding" Height="150" Width="265">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height = "10" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "10" />
                <RowDefinition Height = "*" />
                <RowDefinition Height = "10" />
            </Grid.RowDefinitions>
    
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width = "10" />
                <ColumnDefinition Width = "Auto" />
                <ColumnDefinition Width = "*" />
                <ColumnDefinition Width = "10" />
    
            </Grid.ColumnDefinitions>
    
            <Label Grid.Row="1" Grid.Column="1" Margin="2" Content="Name"/>
    
            **<TextBox Text="{Binding Path=Name, Mode=TwoWay}" Grid.Row="1" Grid.Column="2" Margin="2" />**
    
            <Label Content="Age" Margin="2" Grid.Column="1" Grid.Row="2" />
    
            **<TextBox Text="{Binding Path=Age, Mode=TwoWay}" Grid.Column="2" Grid.Row="2" Margin="2"/>**
    
            <Button Grid.Column="1" Grid.Row="4" Grid.ColumnSpan="2"  Content="Info" Click="Button_Click" />
        </Grid>
    </Window>
    ```
    
- OneWayToSource Data Binding - Data come from UI. Cannot read data from c# file to UI.
    
    ```csharp
    <Window x:Class="DataBinding.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:DataBinding"
            mc:Ignorable="d"
            Title="Data Binding" Height="150" Width="265">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height = "10" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "10" />
                <RowDefinition Height = "*" />
                <RowDefinition Height = "10" />
            </Grid.RowDefinitions>
    
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width = "10" />
                <ColumnDefinition Width = "Auto" />
                <ColumnDefinition Width = "*" />
                <ColumnDefinition Width = "10" />
    
            </Grid.ColumnDefinitions>
    
            <Label Grid.Row="1" Grid.Column="1" Margin="2" Content="Name"/>
    
            **<TextBox Text="{Binding Path=Name, Mode=OneWayToSource}" Grid.Row="1" Grid.Column="2" Margin="2" />**
    
            <Label Content="Age" Margin="2" Grid.Column="1" Grid.Row="2" />
    
            **<TextBox Text="{Binding Path=Age, Mode=OneWayToSource}" Grid.Column="2" Grid.Row="2" Margin="2"/>**
    
            <Button Grid.Column="1" Grid.Row="4" Grid.ColumnSpan="2"  Content="Info" Click="Button_Click" />
        </Grid>
    </Window>
    ```
    
- OneTimeDataBinding - Things can only be updated one time. (Single Time Data Update)
    
    ```csharp
    <Window x:Class="DataBinding.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:DataBinding"
            mc:Ignorable="d"
            Title="Data Binding" Height="150" Width="265">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height = "10" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "Auto" />
                <RowDefinition Height = "10" />
                <RowDefinition Height = "*" />
                <RowDefinition Height = "10" />
            </Grid.RowDefinitions>
    
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width = "10" />
                <ColumnDefinition Width = "Auto" />
                <ColumnDefinition Width = "*" />
                <ColumnDefinition Width = "10" />
    
            </Grid.ColumnDefinitions>
    
            <Label Grid.Row="1" Grid.Column="1" Margin="2" Content="Name"/>
    
            **<TextBox Text="{Binding Path=Name, Mode=OneTime}" Grid.Row="1" Grid.Column="2" Margin="2" />**
    
            <Label Content="Age" Margin="2" Grid.Column="1" Grid.Row="2" />
    
            **<TextBox Text="{Binding Path=Age, Mode=OneTime}" Grid.Column="2" Grid.Row="2" Margin="2"/>**
    
            <Button Grid.Column="1" Grid.Row="4" Grid.ColumnSpan="2"  Content="Info" Click="Button_Click" />
        </Grid>
    </Window>
    ```
    

### ListBox

```csharp
// XAML
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="10"></RowDefinition>
        <RowDefinition Height="*"></RowDefinition>
        <RowDefinition Height="10"></RowDefinition>
    </Grid.RowDefinitions>

    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="10"></ColumnDefinition>
        <ColumnDefinition Width="*"></ColumnDefinition>
        <ColumnDefinition Width="10"></ColumnDefinition>
    </Grid.ColumnDefinitions>

    <ListBox x:Name="ListBoxNames" Grid.Column="1" Grid.Row="1"></ListBox>
</Grid>

// C#
public MainWindow()
{
    InitializeComponent();
    ListBoxNames.ItemsSource = new List<string>()
    {
        "Elton",
        "Jane",
        "Marc"
    };
}
```

- ListBox ItemTemplate - Similar to the Items in Vue
    
    ```csharp
    // XAML FILE
    <ListBox x:Name="ListBoxPeople" Grid.Column="1" Grid.Row="1">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock Text="{Binding Name, StringFormat ='Name: {0}'}"></TextBlock>
                    <TextBlock Text="{Binding Age, StringFormat ='Age: {0}'}"></TextBlock>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    ```
    
- Accessing selected data
    - Multiple
    - Single
    
    ```csharp
    <ListBox x:Name="ListBoxPeople" SelectionMode="Multiple" Grid.Column="1" Grid.Row="1">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock Text="{Binding Name, StringFormat ='Name: {0}'}"></TextBlock>
                    <TextBlock Text="{Binding Age, StringFormat ='Age: {0}'}"></TextBlock>
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
    ```
    

### Password Box

```csharp
// XAML
<PasswordBox Grid.Column="1" Grid.Row="3" Width="300" Height="30" x:Name="PasswordBox"></PasswordBox>

// C#
private void Login(object sender, RoutedEventArgs e)
        {
            string passwordEntered = PasswordBox.Password;
            if (passwordEntered != correctPassword)
            {
                MessageBox.Show("Incorrect Password. Please try again.");
            }
            else
            {
                MessageBox.Show("Successfully Logged in.");
            }
        }
```

- Password change event
    
    ```csharp
    // XAML
    <PasswordBox PasswordChanged="PasswordBox_PasswordChanged" Grid.Column="1" Grid.Row="3" Width="300" Height="30" x:Name="PasswordBox"></PasswordBox>
    <Button Click="Login" x:Name="LoginButton" Grid.Column="1" Grid.Row="5" Width="150" Height="30" IsEnabled="False">Login</Button>
    
    // C#
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        LoginButton.IsEnabled = !string.IsNullOrEmpty(PasswordBox.Password);
    }
    ```