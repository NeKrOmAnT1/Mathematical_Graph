using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Windows;
using Mathematical_Graph.Views;
using System.Linq;


namespace Mathematical_Graph.Models
{
    internal class Methods
    {
        #region Построение графика
        public static PlotModel GenerateGraphModel(double a, double b, double c, string selectedGraph)
        {
            PlotModel graphModel = new PlotModel { Title = "График" };
            LinearAxis xAxis = new LinearAxis { Position = AxisPosition.Bottom };
            LinearAxis yAxis = new LinearAxis { Position = AxisPosition.Left };
            graphModel.Axes.Add(xAxis);
            graphModel.Axes.Add(yAxis);

            LineSeries series = new LineSeries { Title = "График" };

            for (double x = -10; x <= 10; x += 0.1)
            {
                double y = CalculateY(x, a, b, c, selectedGraph);
                if (y >= -10 && y <= 10)
                {
                    series.Points.Add(new DataPoint(x, y));
                }
            }
            graphModel.Series.Add(series);

            return graphModel;
        }
        public static double CalculateY(double x, double a, double b, double c, string selectedGraph)
        {
            switch (selectedGraph)
            {
                case "x*x":
                    return a * x * x;
                case "sin(x)":
                    return Math.Sin(x);
                case "cos(x)":
                    return Math.Cos(x);
                case "a*x*x + b*x + c":
                    return a * x * x + b * x + c;
                default:
                    return 0;
            }
        }
        #endregion
        #region Отправка Email
        public static void SendEmail(string emailText)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Отправитель", "grafikim@mail.ru"));
                message.To.Add(new MailboxAddress("Получатель", "miftahov9548@gmail.com"));
                message.Subject = "Запрос в тех.поддержку";
                var body = new TextPart("plain")
                {
                    Text = emailText
                };
                message.Body = body;

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.mail.ru", 465, true);
                    client.Authenticate("grafikim@mail.ru", "gFzwSUuWJzR4sw9QmPAy");
                    client.Send(message);
                    client.Disconnect(true);
                    OpenMainWindow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex}");
            }
        }
        #endregion
        #region Работа с Windows
        public static void OpenSendEmailWindow()
        {
            SendEmailWindow window = new SendEmailWindow();
            window.Show();
            Window window1 = Application.Current.Windows.OfType<Window>().FirstOrDefault();
            if (window1!= null)
            {
                window1.Close();
            }
        }
        public static void OpenMainWindow()
        {
            MainWindow window = new MainWindow();
            window.Show();
            Window window1 = Application.Current.Windows.OfType<SendEmailWindow>().FirstOrDefault();
            if (window1!= null)
            {
                window1.Close();
            }
        }
        #endregion
    }
}
