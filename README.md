# How to load Search TextBox in DropDown Popup of WPF MultiColumnDropDownControl (SfMultiColumnDropDownControl)?

## About the sample
This example illustrates how to load Search TextBox in DropDown Popup of [WPF MultiColumnDropDownControl](https://www.syncfusion.com/wpf-controls/multi-column-dropdown) (SfMultiColumnDropDownControl)? 

[WPF MultiColumnDropDownControl](https://www.syncfusion.com/wpf-controls/multi-column-dropdown) (SfMultiColumnDropDown) does not provide the direct support to load Search TextBox in DropDown Popup. You can load Search TextBox in DropDown Popup by override the [SfMultiColumnDropDownControl](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfMultiColumnDropDownControl.html) style and Set **Visible** for the **PART_ContentPresenter** **Visibility** property in [WPF MultiColumnDropDownControl](https://www.syncfusion.com/wpf-controls/multi-column-dropdown) (SfMultiColumnDropDown).

```XML

<Style  TargetType="syncfusion:SfMultiColumnDropDownControl">
            <Setter Property="FocusVisualStyle" Value="{x:Null}" />
            <Setter Property="BorderThickness" Value="1" />
            <Setter Property="Padding" Value="2"/>
            <Setter Property="Background" Value="White" />
            <Setter Property="BorderBrush" Value="#FFABADB3" />
            <Setter Property="PopupBorderBrush" Value="Gray" />
            <Setter Property="PopupBorderThickness" Value="1" />
            <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            <Setter Property="IsTabStop" Value="False" />
            <Setter Property="PopupDropDownGridBackground" Value="White" />
            <Setter Property="PopupBackground" Value="White" />
            <Setter Property="Foreground" Value="Black" />
            <Setter Property="SnapsToDevicePixels" Value="True" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="syncfusion:SfMultiColumnDropDownControl">
                        <Border x:Name="PART_RootBorder"
                            Width="{TemplateBinding Width}"
                            Height="{TemplateBinding Height}"
                            Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualState x:Name="Single">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_RootGrid" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_MultiSelectRootGrid" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" KeyTime="0:0:0" />
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_ContentPresenter" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_StackPanel" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Multiple">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_RootGrid" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_MultiSelectRootGrid" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_ContentPresenter" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_StackPanel" Storyboard.TargetProperty="(FrameworkElement.Visibility)">
                                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="0:0:0"/>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="FocusStates">
                                    <VisualState x:Name="Focused">
                                        <Storyboard BeginTime="0">
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_RootBorder" Storyboard.TargetProperty="BorderBrush">
                                                <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource FocusedThemeBrush}" />
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unfocused" />
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Grid>
                                <Popup x:Name="PART_Popup"
                                   MinWidth="{TemplateBinding PopupMinWidth}"
                                   MinHeight="{TemplateBinding PopupMinHeight}"
                                   MaxWidth="{TemplateBinding PopupMaxWidth}"
                                   MaxHeight="{TemplateBinding PopupMaxHeight}"
                                   IsOpen="{Binding Path=IsDropDownOpen,
                                                    Mode=TwoWay,
                                                    RelativeSource={RelativeSource TemplatedParent}}"
                                   Style="{StaticResource PopupStyle}" >
                                    <Border Name="PART_PopupBorder"
                                        BorderBrush="{TemplateBinding PopupBorderBrush}"
                                        BorderThickness="{TemplateBinding PopupBorderThickness}" >
                                        <Grid Background="{TemplateBinding PopupBackground}">
                                            <Grid.RowDefinitions>
                                                <RowDefinition Height="Auto"/>
                                                <RowDefinition Height="*" />
                                                <RowDefinition Height="Auto" />
                                            </Grid.RowDefinitions>
                                            <ContentPresenter x:Name="PART_ContentPresenter" 
                                                          ContentTemplate="{TemplateBinding HeaderTemplate}" 
                                                          SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" 
                                                          Visibility="Visible"/>
                                            <ContentControl x:Name="PART_PopupContent" Grid.Row="1">
                                                <syncfusion:SfDataGrid x:Name="PART_SfDataGrid"
                                                              Margin="0"
                                                              BorderThickness="0,0,0,1"
                                                              AllowDraggingColumns="False"
                                                              AllowEditing="False"
                                                              AllowFiltering="False"
                                                              AllowGrouping="False"
                                                              AllowResizingColumns="False"
                                                              AllowRowHoverHighlighting="True"
                                                              AutoGenerateColumns="{TemplateBinding AutoGenerateColumns}"
                                                              Background="{TemplateBinding PopupDropDownGridBackground}"
                                                              ColumnSizer="{TemplateBinding GridColumnSizer}"
                                                              FocusVisualStyle="{x:Null}"
                                                              Focusable="False"
                                                              ItemsSource="{TemplateBinding ItemsSource}"
                                                              NavigationMode="Row"
                                                              SelectedIndex="{Binding Path=SelectedIndex,
                                                                                      RelativeSource={RelativeSource TemplatedParent},
                                                                                      Mode=TwoWay}"
                                                                  />
                                            </ContentControl>
                                            <Grid Grid.Row="2">
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="*"/>
                                                    <ColumnDefinition Width="Auto"/>
                                                </Grid.ColumnDefinitions>
                                                <StackPanel x:Name="PART_StackPanel"
                                                        Height="44"
                                                        HorizontalAlignment="Right"
                                                        Orientation="Horizontal" 
                                                        Visibility="Collapsed">

                                                    <Button x:Name="PART_OkButton"
                                                        Width="80"
                                                        Margin="0,10,8,10"
                                                        HorizontalAlignment="Center"
                                                        Content="{syncfusion:GridLocalizationResourceExtension ResourceName=OK}"
                                                        Foreground="{TemplateBinding Foreground}"
                                                        FontFamily="{TemplateBinding FontFamily}"
                                                        FontSize="{TemplateBinding FontSize}"
                                                        FontStretch="{TemplateBinding FontWeight}"
                                                        FontStyle="{TemplateBinding FontStyle}"
                                                        FontWeight="{TemplateBinding FontWeight}"/>

                                                    <Button x:Name="PART_CancelButton"
                                                        Width="80"
                                                        Margin="0,10,8,10"
                                                        HorizontalAlignment="Center"
                                                        FontFamily="{TemplateBinding FontFamily}"
                                                        FontSize="{TemplateBinding FontSize}"
                                                        FontStretch="{TemplateBinding FontWeight}"
                                                        FontStyle="{TemplateBinding FontStyle}"
                                                        FontWeight="{TemplateBinding FontWeight}"
                                                        Content="{syncfusion:GridLocalizationResourceExtension ResourceName=Cancel}"
                                                        Foreground="{TemplateBinding Foreground}"
                                                        />

                                                </StackPanel>
                                                <Thumb x:Name="PART_ThumbGripper" 
                                                   Grid.Column="1"
                                                   Visibility="{TemplateBinding ResizingThumbVisibility}"
                                                   HorizontalAlignment="Right" 
                                                   VerticalAlignment="Bottom"
                                                   Cursor="SizeNWSE">
                                                    <Thumb.Template>
                                                        <ControlTemplate>
                                                            <Grid Background="Transparent">
                                                                <Path Width="8"
                                                                  Height="8"
                                                                  Data="M36.396,36.017 L47.901,36.017 47.901,47.521999 36.396,47.521999 z M18.198,36.017 L29.716,36.017 29.716,47.521999 18.198,47.521999 z M0,36.017 L11.511999,36.017 11.511999,47.521999 0,47.521999 z M36.396,18.191001 L47.901,18.191001 47.901,29.696 36.396,29.696 z M18.198,18.191 L29.716,18.191 29.716,29.696 18.198,29.696 z M36.396,0 L47.901,0 47.901,11.512 36.396,11.512 z"
                                                                  Fill="#FF727272"
                                                                  Stretch="Fill" />
                                                            </Grid>
                                                        </ControlTemplate>
                                                    </Thumb.Template>
                                                </Thumb>
                                            </Grid>
                                        </Grid>
                                    </Border>
                                </Popup>
                                <Grid x:Name="PART_RootGrid" SnapsToDevicePixels="True">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*" />
                                        <ColumnDefinition Width="Auto" />
                                    </Grid.ColumnDefinitions>
                                    <TextBox x:Name="PART_TextBox"
                                     Padding="{TemplateBinding Padding}"
                                     Grid.Column="0"
                                     Background="{TemplateBinding Background}"
                                     FlowDirection="{TemplateBinding FlowDirection}"
                                     FontFamily="{TemplateBinding FontFamily}"
                                     FontSize="{TemplateBinding FontSize}"
                                     FontStretch="{TemplateBinding FontStretch}"
                                     FontStyle="{TemplateBinding FontStyle}"
                                     FontWeight="{TemplateBinding FontWeight}"
                                     Foreground="{TemplateBinding Foreground}"
                                     IsReadOnly="{TemplateBinding ReadOnly}"
                                     Style="{StaticResource TextBoxStyle}"
                                     TabIndex="{TemplateBinding TabIndex}"
                                     Text="{Binding Path=Text,
                                                    RelativeSource={RelativeSource TemplatedParent},
                                                    Mode=TwoWay}"
                                     TextAlignment="{TemplateBinding TextAlignment}" />
                                    <Border Grid.Column="1"
                                    Margin="0"
                                    BorderThickness="{TemplateBinding BorderThickness}">
                                        <ToggleButton x:Name="PART_ToggleButton"
                                              VerticalContentAlignment="Center"
                                              Style="{StaticResource DropDownToggleButtonStyle}" />
                                    </Border>
                                </Grid>
                                <Grid x:Name="PART_MultiSelectRootGrid" SnapsToDevicePixels="True" Visibility="Collapsed">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*" />
                                        <ColumnDefinition MinWidth="{DynamicResource {x:Static SystemParameters.VerticalScrollBarWidthKey}}" Width="0" />
                                    </Grid.ColumnDefinitions>

                                    <Border Grid.ColumnSpan="2"
                                    Margin="0"
                                    BorderThickness="{TemplateBinding BorderThickness}">
                                        <ToggleButton x:Name="PART_MultiSelectToggleButton"
                                              VerticalContentAlignment="Center"
                                              Style="{StaticResource MultiSelectDropDownToggleButtonStyle}" />
                                    </Border>
                                    <ItemsControl x:Name="PART_ItemsControl" 
                                          Padding="{TemplateBinding Padding}" 
                                          IsTabStop="False"
                                          IsHitTestVisible="False"
                                          MaxWidth="{Binding Path=ActualWidth,
                                                             RelativeSource={RelativeSource TemplatedParent}}">
                                        <ItemsControl.ItemsPanel>
                                            <ItemsPanelTemplate>
                                                <StackPanel Orientation="Horizontal" VerticalAlignment="Center" Margin="2"/>
                                            </ItemsPanelTemplate>
                                        </ItemsControl.ItemsPanel>
                                    </ItemsControl>
                                </Grid>
                            </Grid>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsEnabled" Value="false">
                                <Setter Property="Opacity" TargetName="PART_RootBorder" Value="0.56"/>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="true">
                                <Setter Property="BorderBrush" TargetName="PART_RootBorder" Value="#FF7EB4EA"/>
                            </Trigger>
                            <Trigger Property="IsKeyboardFocused" Value="true">
                                <Setter Property="BorderBrush" TargetName="PART_RootBorder" Value="#FF569DE5"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
</Style>

```

![Shows the search textbox in SfMultiColumnDropDownControl](SearchTextBox.gif)

Take a moment to peruse the [WPF MultiColumnDropDown - Load custom control in drop-down](https://help.syncfusion.com/wpf/multi-column-dropdown/selection#load-custom-control-in-drop-down) documentation, where you can find about load custom control in drop-down with code examples.

## Requirements to run the demo
Visual Studio 2015 and above versions
