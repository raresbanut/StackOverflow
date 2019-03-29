namespace StackOverflow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    using EnvDTE80;

    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.TableControl;

    using StackOverflow.UrlHandling;
    using Process = System.Diagnostics.Process;

    /// <summary>
    /// Interaction logic for StackOverflowHintsControl.
    /// </summary>
    public partial class StackOverflowHintsControl : UserControl
    {
        /// <summary>The error list.</summary>
        protected IList<Error> ErrorList;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackOverflowHintsControl"/> class.
        /// </summary>
        public StackOverflowHintsControl()
        {
            this.InitializeComponent();
            ErrorList = new List<Error>();
            this.MyDatagrid.ItemsSource = ErrorList;
        }

        /// <summary>The update button_ on click async.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async void UpdateButton_OnClickAsync(object sender, RoutedEventArgs e)
        {
            ErrorList.Clear();
            var dte = StackOverflowHintsPackage.GetDte2();

            var errorList = dte.ToolWindows.ErrorList as IErrorList;
            var errorList2 = dte.ToolWindows.ErrorList as ErrorList;

            try
            {
                // placed in dictionary for easy access later
                var entries = (errorList?.TableControl.Entries ?? Enumerable.Empty<ITableEntryHandle>())
                    .Select((entry, i) => new { Entry = entry, Index = i + 1 })
                    .ToDictionary(it => it.Index, it => it.Entry);

                var errors = errorList2.ErrorItems;
                for (int i = 1; i <= errors.Count; i++)
                {
                    ErrorItem error = errors.Item(i);
                    entries[i].TryGetValue("errorcode", out var errorCode);

                    var searchUrl = new SearchUrl
                                        {
                                            Title = string.Format("{0} {1}", errorCode != null ? errorCode.ToString(): string.Empty, error.Description)
                                        };

                    var tooltip = "www.stackoverflow.com";

                    var requestManager = new RequestManager();
                    var items = await requestManager.Search(searchUrl);
                    if (items != null && items.Items.Any())
                    {
                        tooltip = items.Items.FirstOrDefault()?.Link;
                    }
                    
                    var item = new Error
                                   {
                                       Code = errorCode?.ToString(),
                                       Description = error.Description,
                                       Tooltip = tooltip,
                                       Project = error.Project,
                                       FileName = error.FileName,
                                       Line = error.Line.ToString()
                                   };

                    ErrorList.Add(item);
                }


                this.MyDatagrid.ItemsSource = ErrorList;
                this.MyDatagrid.Items.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Exception was caught: {exception}");
            }
        }

        private void Tooltip_OnClick(object sender, RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(link.NavigateUri.AbsoluteUri);
        }
    }
}