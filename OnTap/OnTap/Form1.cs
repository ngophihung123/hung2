using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OnTap
{
    public partial class Form1 : Form
    {   
        hungEntities3 db = new hungEntities3();
        public Form1()
        {
            InitializeComponent();
            //lvDanhSachPhim.SelectedIndexChanged += lvDanhSachPhim_SelectedIndexChanged;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        void LoadData()
        {

            using (var context = new hungEntities3())
            {
                var phims = context.Phims.ToList();
                
                foreach (var phim in phims)
                {
                    ListViewItem item = new ListViewItem(phim.MaDon);
                    item.SubItems.Add(phim.TenPhim);

                    item.SubItems.Add(phim.TheLoai);
                    item.SubItems.Add(phim.NgayCongChieu.ToString());
                    item.SubItems.Add(phim.DoTuoiQuyDinh.ToString());
                    /*item.SubItems.Add(phim.QuocGia);
                    item.SubItems.Add(phim.DinhDang);
                    item.SubItems.Add(phim.PhuThu);
                    item.SubItems.Add(phim.GiaTienPhuThu.ToString());*/
                    

                    lvDanhSachPhim.Items.Add(item);
                }
            }

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn tắt chương trình?", "Xác nhận tắt chương trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void rad2D_CheckedChanged(object sender, EventArgs e)
        {
            if ( rad2D.Checked )
            {
                labPhuThuGheDoi.Visible = true;
                txtPhuThuGheDoi.Visible =true;
                labPhuThuSuatChieuDacBiet.Visible = false;
                txtPhuThuSuatChieuDacBiet.Visible = false;
                txtPhuThuSuatChieuDacBiet.Clear();
            }
      
          
            
        }

        private void rad3D_CheckedChanged(object sender, EventArgs e)
        {
            if( rad3D.Checked )
            {
                labPhuThuSuatChieuDacBiet.Visible = true;
                txtPhuThuSuatChieuDacBiet.Visible =true;
                labPhuThuGheDoi.Visible = false;
                txtPhuThuGheDoi.Visible = false;
                txtPhuThuGheDoi.Clear();
            }    
          
        }
        void Reset()
        {
            txtMaDon.Clear();
            txtMaDon.Focus();
            txtTenPhim.Clear();
            txtQuocGia.Clear();
            radTinhCam.Checked = true; radHanhDong.Checked = false;
            dtpNgayCongChieu.Value = DateTime.Now;
            txtDoTuoi.Clear();
            rad2D.Checked = true; rad3D.Checked = false;
            labPhuThuGheDoi.Visible = true;
            txtPhuThuGheDoi.Visible = true;
            txtPhuThuGheDoi.Clear();
            labPhuThuSuatChieuDacBiet.Visible = false;
            txtPhuThuSuatChieuDacBiet.Visible = false;
            txtPhuThuSuatChieuDacBiet.Clear();
            btnLuu.Enabled = false;
            LoadData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
           Reset();
        }
        private bool KiemTraTrungMaDon(string maDon)
        {

           return db.Phims.Any(p => p.MaDon == maDon);
    }

        int doTuoiQuiDinh;
        int phuthudacbiet;
        int phuthughedoi;
        private void txtMaDon_TextChanged(object sender, EventArgs e)
        {
            if (txtMaDon.Text == "" || txtTenPhim.Text == "" || txtQuocGia.Text == "" || txtDoTuoi.Text == "" || (txtPhuThuGheDoi.Text == "" && txtPhuThuSuatChieuDacBiet.Text == ""))
            {
                btnLuu.Enabled = false;
            }
            else { btnLuu.Enabled = true; }
        }

        private void txtTenPhim_TextChanged(object sender, EventArgs e)
        {
            if (txtMaDon.Text == "" || txtTenPhim.Text == "" || txtQuocGia.Text == "" || txtDoTuoi.Text == "" || (txtPhuThuGheDoi.Text == "" && txtPhuThuSuatChieuDacBiet.Text == ""))
            {
                btnLuu.Enabled = false;
            }
            else { btnLuu.Enabled = true; }
        }

        private void txtQuocGia_TextChanged(object sender, EventArgs e)
        {
            if (txtMaDon.Text == "" || txtTenPhim.Text == "" || txtQuocGia.Text == "" || txtDoTuoi.Text == "" || (txtPhuThuGheDoi.Text == "" && txtPhuThuSuatChieuDacBiet.Text == ""))
            {
                btnLuu.Enabled = false;
            }
            else { btnLuu.Enabled = true; }
        }

        private void txtDoTuoi_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDoTuoi.Text, out doTuoiQuiDinh) || doTuoiQuiDinh < 0 || doTuoiQuiDinh > 100 || txtMaDon.Text == "" || txtTenPhim.Text == "" || txtQuocGia.Text == "" || txtDoTuoi.Text == "" || int.Parse(txtDoTuoi.Text) < 0 || (txtPhuThuGheDoi.Text == "" && txtPhuThuSuatChieuDacBiet.Text == "" ))
            {
                btnLuu.Enabled = false;
            }
            else { btnLuu.Enabled = true; }
        }

        private void txtPhuThuGheDoi_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPhuThuGheDoi.Text, out doTuoiQuiDinh) || txtMaDon.Text == "" || txtTenPhim.Text == "" || txtQuocGia.Text == "" || txtDoTuoi.Text == "" || (txtPhuThuGheDoi.Text == "" && txtPhuThuSuatChieuDacBiet.Text == ""))
            {
                btnLuu.Enabled = false;
            }
            else { btnLuu.Enabled = true; }
        }

        private void txtPhuThuSuatChieuDacBiet_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPhuThuSuatChieuDacBiet.Text, out doTuoiQuiDinh) || txtMaDon.Text == "" || txtTenPhim.Text == "" || txtQuocGia.Text == "" || txtDoTuoi.Text == "" || (txtPhuThuGheDoi.Text == "" && txtPhuThuSuatChieuDacBiet.Text == ""))
            {
                btnLuu.Enabled = false;
            }
            else { btnLuu.Enabled = true; }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            string maDon = txtMaDon.Text;

            // Kiểm tra xem mã đơn đã tồn tại chưa
            if (KiemTraTrungMaDon(maDon))
            {
                MessageBox.Show("Mã đơn đã tồn tại. Vui lòng chọn mã đơn khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Phim p = new Phim();
            p.MaDon = txtMaDon.Text;
            p.TenPhim = txtTenPhim.Text;
            p.QuocGia = txtQuocGia.Text;
            if (radTinhCam.Checked)
            {
                p.TheLoai = radTinhCam.Text;
            }
            else p.TheLoai = radHanhDong.Text;
            p.NgayCongChieu = dtpNgayCongChieu.Value;
            p.DoTuoiQuyDinh = Convert.ToInt32(txtDoTuoi.Text);
            if (rad2D.Checked)
            {
                p.DinhDang = rad2D.Text;
                p.TenPhuThu = "ghế đôi";
                p.GiaTienPhuThu = Convert.ToDecimal(txtPhuThuGheDoi.Text);
            }
            else
            {
                p.DinhDang = rad3D.Text;
                p.TenPhuThu = "đặc biệt";
                p.GiaTienPhuThu = Convert.ToDecimal(txtPhuThuSuatChieuDacBiet.Text);

            }
            db.Phims.Add(p);
            db.SaveChanges();

            lvDanhSachPhim.Items.Clear();
            LoadData();
        }
        private void lvDanhSachPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachPhim.SelectedItems.Count > 0)
            {
         
                ListViewItem selectedItem = lvDanhSachPhim.SelectedItems[0];

          
                string id = selectedItem.SubItems[0].Text;


                
                var selectedPhim = db.Phims.FirstOrDefault(p => p.MaDon == id);

                if (selectedPhim != null)
                {
                    // Display the details in input controls (assuming TextBoxes for this example)
                    txtMaDon.Text = selectedPhim.MaDon.ToString();
                    txtTenPhim.Text = selectedPhim.TenPhim.ToString();
                    txtQuocGia.Text = selectedPhim.QuocGia.ToString();
                    if (selectedPhim.TheLoai == "Tình cảm")
                    {
                        radTinhCam.Checked = true;
                    }
                    else radHanhDong.Checked = true;

                    dtpNgayCongChieu.Value = selectedPhim.NgayCongChieu.Value;

                    txtDoTuoi.Text = selectedPhim.DoTuoiQuyDinh.ToString();
                    if (selectedPhim.DinhDang == "2D")
                    {
                        rad2D.Checked = true;
                        txtPhuThuGheDoi.Text = selectedPhim.GiaTienPhuThu.ToString();
                    }
                    else
                    {
                        rad3D.Checked = true;
                        txtPhuThuSuatChieuDacBiet.Text = selectedPhim.GiaTienPhuThu.ToString();
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSachPhim.SelectedItems.Count > 0)
            {
                
                ListViewItem selectedItem = lvDanhSachPhim.SelectedItems[0];

               
                string id = selectedItem.SubItems[0].Text;

                
                DialogResult result = MessageBox.Show("Bạn có chắc muôn số bộ phim?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                    var selectedPhim = db.Phims.FirstOrDefault(p => p.MaDon == id);

                    if (selectedPhim != null)
                    {
                        db.Phims.Remove(selectedPhim);
                        db.SaveChanges();
                    }

             
                    lvDanhSachPhim.Items.Remove(selectedItem);

                    // Select the next item in the ListView
                    int index = Math.Min(selectedItem.Index, lvDanhSachPhim.Items.Count - 1);
                    if (index >= 0 && lvDanhSachPhim.Items.Count > 0)
                    {
                        lvDanhSachPhim.Items[index].Selected = true;
                        lvDanhSachPhim.Select();
                    }
                    else
                    {
                        // If there are no items left, clear the details or load default information
                        Reset(); // You need to implement ClearDetails() to reset your UI to default state
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvDanhSachPhim.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDanhSachPhim.SelectedItems[0];
                string id = selectedItem.SubItems[0].Text;

                var selectedPhim = db.Phims.FirstOrDefault(p => p.MaDon == id);

                if (selectedPhim != null)
                {
                    // Update the properties of the selectedPhim object
                    selectedPhim.TenPhim = txtTenPhim.Text;
                    selectedPhim.QuocGia = txtQuocGia.Text;
                    selectedPhim.TheLoai = radTinhCam.Checked ? radTinhCam.Text : radHanhDong.Text;
                    selectedPhim.NgayCongChieu = dtpNgayCongChieu.Value;
                    selectedPhim.DoTuoiQuyDinh = Convert.ToInt32(txtDoTuoi.Text);

                    if (rad2D.Checked)
                    {
                        selectedPhim.DinhDang = rad2D.Text;
                        selectedPhim.TenPhuThu = "ghế đôi";
                        selectedPhim.GiaTienPhuThu = Convert.ToDecimal(txtPhuThuGheDoi.Text);
                    }
                    else
                    {
                        selectedPhim.DinhDang = rad3D.Text;
                        selectedPhim.TenPhuThu = "đặc biệt";
                        selectedPhim.GiaTienPhuThu = Convert.ToDecimal(txtPhuThuSuatChieuDacBiet.Text);
                    }

                    // Save the changes to the database
                    db.SaveChanges();

                    // Update the ListView item
                    selectedItem.SubItems[1].Text = selectedPhim.TenPhim;
                    selectedItem.SubItems[2].Text = selectedPhim.TheLoai;
                    selectedItem.SubItems[3].Text = selectedPhim.NgayCongChieu.ToString();
                    selectedItem.SubItems[4].Text = selectedPhim.DoTuoiQuyDinh.ToString();
                    lvDanhSachPhim.Items.Clear();
                    // Clear the input fields
                    Reset();
                }
            }
        }
        private void SapXepDanhSach()
        {

            List<Phim> danhSachPhim = lvDanhSachPhim.Items.Cast<ListViewItem>()
               .Select(item => item.Tag as Phim)
               .Where(Phim => Phim != null && Phim.NgayCongChieu != null && Phim.DoTuoiQuyDinh != null)
               .ToList();

            // Sắp xếp danh sách theo ngày công chiếu tăng dần, độ tuổi qui định giảm dần
            danhSachPhim = danhSachPhim
                .OrderBy(Phim => Phim.NgayCongChieu)
                .ThenByDescending(Phim => Phim.DoTuoiQuyDinh)
                .ToList();


            lvDanhSachPhim.Items.Clear();


            foreach (var Phim in danhSachPhim)
            {
                ListViewItem item = new ListViewItem(Phim.MaDon);
                item.Tag = Phim;
                item.SubItems.Add(Phim.TenPhim);
                item.SubItems.Add(Phim.TheLoai);
                item.SubItems.Add(Phim.NgayCongChieu?.ToString());

                lvDanhSachPhim.Items.Add(item);
            }
        }

        private void btnXapXep_Click(object sender, EventArgs e)
        {
            SapXepDanhSach();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            

           
            decimal doanhThu2D = 0;
            decimal doanhThu3D = 0;
            int soLuong2D = 0;
            int soLuong3D = 0;
            using (var context = new hungEntities3())
            {
                var phims = context.Phims.ToList();
                
                
                foreach (var Phim in phims)
                {
             

                    if (Phim.DinhDang == "2D")
                    {
                        soLuong2D++;


                        doanhThu2D += Phim.GiaTienPhuThu ?? 0;
                    }
                    else if (Phim.DinhDang == "3D")
                    {
                        soLuong3D++;


                        doanhThu3D += Phim.GiaTienPhuThu ?? 0;
                    }
                }
            
            }


            string thongTin = $"2D: Số lượng phim: {soLuong2D}, Doanh thu: {doanhThu2D:C}\n";
            thongTin += $"3D: Số lượng phim: {soLuong3D}, Doanh thu: {doanhThu3D:C}";

            MessageBox.Show(thongTin, "Thống kê phim", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
}
