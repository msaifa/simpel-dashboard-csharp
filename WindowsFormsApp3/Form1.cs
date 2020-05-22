/*
 
    created by msaifa
    @ 2020
 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Data.OleDb;

using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;


namespace WindowsFormsApp3
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        // deklarasi variabel dan db access
        OleDbConnection koneksi;
        OleDbCommand oleDbCmd = new OleDbCommand();
        String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Pendidikan\Pemrograman Visual\Dashboard\db\db.mdb;Persist Security Info=False";

        public Form1()
        {
            InitializeComponent();

            // chart 1 = pendapatan
            OleDbConnection connection = new OleDbConnection(connParam);

            // yuk mulai implement data chart
            // buat query dan koneksikan ke db
            OleDbCommand command = new OleDbCommand("select * from qPendapatan", connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            // fetch data
            reader.Read();

            int jan = reader.GetInt32(0);
            int feb = Convert.ToInt32(reader[1].ToString());
            int mar = Convert.ToInt32(reader[2].ToString());
            int apr = Convert.ToInt32(reader[3].ToString());
            int mei = Convert.ToInt32(reader[4].ToString());


            cartesianChart9.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { jan, feb,mar,apr,mei}
                }
            };

            cartesianChart9.AxisX.Add(new Axis
            {
                Title = "Bulan",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart9.DataClick += CartesianChart9OnDataClick;

            // always call Close when done reading.
            reader.Close();

            // ================================================================================================================================================
            // lanjut chart kedua
            // lanjut chart kedua
            command = new OleDbCommand("select * from qTunai", connection);
            reader = command.ExecuteReader();

            reader.Read();
            jan = Convert.ToInt32(reader[0].ToString());
            feb = Convert.ToInt32(reader[1].ToString());
            mar = Convert.ToInt32(reader[2].ToString());
            apr = Convert.ToInt32(reader[3].ToString());
            mei = Convert.ToInt32(reader[4].ToString());

            cartesianChart4.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Tunai",
                    Values = new ChartValues<double> { jan, feb,mar,apr,mei}
                }
            };

            // lanjut chart kedua
            command = new OleDbCommand("select * from qHutang", connection);
            reader = command.ExecuteReader();

            reader.Read();
            jan = Convert.ToInt32(reader[0].ToString());
            feb = Convert.ToInt32(reader[1].ToString());
            mar = Convert.ToInt32(reader[2].ToString());
            apr = Convert.ToInt32(reader[3].ToString());
            mei = Convert.ToInt32(reader[4].ToString());

            //adding series will update and animate the chart automatically
            cartesianChart4.Series.Add(new ColumnSeries
            {
                Title = "Hutang",
                Values = new ChartValues<double> { jan, feb, mar, apr, mei }
            });

            cartesianChart4.AxisX.Add(new Axis
            {
                Title = "Hutang",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "Mei"  }
            });

            // ================================================================================================================================================
            // lanjut chart kedua
            // lanjut chart kedua
            command = new OleDbCommand("select * from qMingguan", connection);
            reader = command.ExecuteReader();

            reader.Read();
            int sen = Convert.ToInt32(reader[0].ToString());

            int sel = 0;

            reader.Read();
            int rab = Convert.ToInt32(reader[0].ToString());

            reader.Read();
            int kam = Convert.ToInt32(reader[0].ToString());

            reader.Read();
            int jum = Convert.ToInt32(reader[0].ToString());

            reader.Read();
            int sab = Convert.ToInt32(reader[0].ToString());

            reader.Read();
            int min = Convert.ToInt32(reader[0].ToString());

            cartesianChart8.Series = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Title = "Senin",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), sen),
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Selasa",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), sel),
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Rabu",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), rab),
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Kamis",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), kam),
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Jumat",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), jum),
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Sabtu",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), sab),
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Minggu",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new System.DateTime(2020, 5, 1), 0),
                        new DateTimePoint(new System.DateTime(2020, 5, 13), min),
                    },
                    LineSmoothness = 0
                }
            };

            // ================================================================================================================================================
            // lanjut chart kedua
            // lanjut chart kedua
            command = new OleDbCommand("select * from qPelanggan", connection);
            reader = command.ExecuteReader();

            // chart 3
            cartesianChart3.Series = new SeriesCollection
            {
                new StackedRowSeries
                {
                    Values = new ChartValues<double> { },
                    StackMode = StackMode.Percentage,
                    DataLabels = true,
                    LabelPoint = p => p.X.ToString()
                }
            };

            while (reader.Read())
            {
                cartesianChart3.Series[0].Values.Add(Convert.ToDouble(reader[0]));
            }

            cartesianChart3.AxisY.Add(new Axis
            {
                Title = "",
                Labels = new[] { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu" }
            });

            var tooltip = new DefaultTooltip { SelectionMode = TooltipSelectionMode.SharedYValues };

            cartesianChart3.DataTooltip = tooltip;

            pieChart1.InnerRadius = 10;
            pieChart1.LegendLocation = LegendLocation.Right;

            // ================================================================================================================================================
            // lanjut chart kedua
            // lanjut chart kedua

            command = new OleDbCommand("select * from qKategori", connection);
            reader = command.ExecuteReader();

            pieChart1.Series = new SeriesCollection{ };

            while (reader.Read())
            {
                pieChart1.Series.Add(
                    new PieSeries
                        {
                            Title = reader[2].ToString(),
                            Values = new ChartValues<double> { Convert.ToDouble(reader[1].ToString()) },
                            DataLabels = true
                        }
                );
            }

            // ================================================================================================================================================
            // lanjut chart kedua
            // lanjut chart kedua

            command = new OleDbCommand("select * from qGenderWanita", connection);
            reader = command.ExecuteReader();

            cartesianChart6.Series = new SeriesCollection{ };

            reader.Read();
            sen = Convert.ToInt32(reader[0].ToString() == null ? reader[0].ToString() : "0");
            sel = Convert.ToInt32(reader[1].ToString() == null ? reader[1].ToString() : "0");
            rab = Convert.ToInt32(reader[2].ToString() == null ? reader[2].ToString() : "0");
            kam = Convert.ToInt32(reader[3].ToString() == null ? reader[3].ToString() : "0");
            jum = Convert.ToInt32(reader[4].ToString() == null ? reader[4].ToString() : "0");
            sab = Convert.ToInt32(reader[5].ToString() == null ? reader[5].ToString() : "0");
            sab = Convert.ToInt32(reader[6].ToString() == null ? reader[6].ToString() : "0");

            cartesianChart6.Series.Add(
                new StackedRowSeries
                {
                    Title = "Female",
                    Values = new ChartValues<double> { sen, sel, rab, kam, jum, sab, min }
                }
            );

            command = new OleDbCommand("select * from qGenderPria", connection);
            reader = command.ExecuteReader();

            cartesianChart6.Series = new SeriesCollection { };

            reader.Read();
            sen = Convert.ToInt32(reader[0].ToString() == null ? reader[0].ToString() : "0");
            sel = Convert.ToInt32(reader[1].ToString() == null ? reader[1].ToString() : "0");
            rab = Convert.ToInt32(reader[2].ToString() == null ? reader[2].ToString() : "0");
            kam = Convert.ToInt32(reader[3].ToString() == null ? reader[3].ToString() : "0");
            jum = Convert.ToInt32(reader[4].ToString() == null ? reader[4].ToString() : "0");
            sab = Convert.ToInt32(reader[5].ToString() == null ? reader[5].ToString() : "0");
            sab = Convert.ToInt32(reader[6].ToString() == null ? reader[6].ToString() : "0");

            cartesianChart6.Series.Add(
                new StackedRowSeries
                {
                    Title = "Male",
                    Values = new ChartValues<double> { sen, sel, rab, kam, jum, sab, min }
                }
            );

            cartesianChart6.AxisX.Add(new Axis
            {
                Title = "Age Range",
                Labels = new[] { "0-20", "20-35", "35-45", "45-55", "55-65", "65-70", ">70" }
            });

            tooltip = new DefaultTooltip
            {
                SelectionMode = TooltipSelectionMode.SharedYValues
            };

            cartesianChart6.DataTooltip = tooltip;

            // ================================================================================================================================================
            // lanjut chart kedua
            // lanjut chart kedua
            command = new OleDbCommand("select * from qBarang", connection);
            reader = command.ExecuteReader();

            cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> {},
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };

            while (reader.Read())
            {
                cartesianChart2.Series[0].Values.Add(Convert.ToDouble(reader[0]));
            }

            cartesianChart2.AxisX.Add(new Axis
            {
                Labels = new[]
                {
                    "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu"
                }
            });

        }

        private void CartesianChart9OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    
