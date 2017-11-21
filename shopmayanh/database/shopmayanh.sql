/*
Navicat MySQL Data Transfer

Source Server         : baitap
Source Server Version : 50617
Source Host           : localhost:3306
Source Database       : shopmayanh

Target Server Type    : MYSQL
Target Server Version : 50617
File Encoding         : 65001

Date: 2017-01-13 00:19:17
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for chitietdondathang
-- ----------------------------
DROP TABLE IF EXISTS chitietdondathang;
CREATE TABLE chitietdondathang (
  MaChiTietDonDatHang int IDENTITY(1,1) primary key not null,
  MaDonDatHang int ,
  MaSP int ,
  SoLuong int ,
  GiaBan int ,
  ThanhTien int ,
  PRIMARY KEY (MaChiTietDonDatHang)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of chitietdondathang
-- ----------------------------
INSERT INTO chitietdondathang VALUES ('1', '4', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('2', '5', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('3', '5', '6', '1', '12029000', '12029000');
INSERT INTO chitietdondathang VALUES ('4', '5', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('5', '5', '19', '1', '7288000', '7288000');
INSERT INTO chitietdondathang VALUES ('6', '6', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('7', '6', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('8', '6', '13', '1', '24289000', '24289000');
INSERT INTO chitietdondathang VALUES ('9', '6', '6', '2', '12029000', '24058000');
INSERT INTO chitietdondathang VALUES ('10', '6', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('11', '6', '24', '1', '11000000', '11000000');
INSERT INTO chitietdondathang VALUES ('12', '7', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('13', '7', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('14', '7', '13', '1', '24289000', '24289000');
INSERT INTO chitietdondathang VALUES ('15', '7', '6', '2', '12029000', '24058000');
INSERT INTO chitietdondathang VALUES ('16', '7', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('17', '7', '24', '1', '11000000', '11000000');
INSERT INTO chitietdondathang VALUES ('18', '8', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('19', '8', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('20', '8', '13', '1', '24289000', '24289000');
INSERT INTO chitietdondathang VALUES ('21', '8', '6', '2', '12029000', '24058000');
INSERT INTO chitietdondathang VALUES ('22', '8', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('23', '8', '24', '1', '11000000', '11000000');
INSERT INTO chitietdondathang VALUES ('24', '9', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('25', '9', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('26', '9', '13', '1', '24289000', '24289000');
INSERT INTO chitietdondathang VALUES ('27', '9', '6', '2', '12029000', '24058000');
INSERT INTO chitietdondathang VALUES ('28', '9', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('29', '9', '24', '1', '11000000', '11000000');
INSERT INTO chitietdondathang VALUES ('30', '10', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('31', '10', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('32', '10', '13', '1', '24289000', '24289000');
INSERT INTO chitietdondathang VALUES ('33', '10', '6', '2', '12029000', '24058000');
INSERT INTO chitietdondathang VALUES ('34', '10', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('35', '10', '24', '1', '11000000', '11000000');
INSERT INTO chitietdondathang VALUES ('36', '11', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('37', '11', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('38', '11', '13', '1', '24289000', '24289000');
INSERT INTO chitietdondathang VALUES ('39', '11', '6', '2', '12029000', '24058000');
INSERT INTO chitietdondathang VALUES ('40', '11', '7', '1', '10359000', '10359000');
INSERT INTO chitietdondathang VALUES ('41', '11', '24', '1', '11000000', '11000000');
INSERT INTO chitietdondathang VALUES ('42', '12', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('43', '12', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('44', '12', '5', '2', '6900000', '13800000');
INSERT INTO chitietdondathang VALUES ('45', '12', '8', '2', '7959000', '15918000');
INSERT INTO chitietdondathang VALUES ('46', '13', '3', '1', '13500000', '13500000');
INSERT INTO chitietdondathang VALUES ('47', '13', '12', '1', '15990000', '15990000');
INSERT INTO chitietdondathang VALUES ('48', '13', '5', '2', '6900000', '13800000');
INSERT INTO chitietdondathang VALUES ('49', '13', '8', '2', '7959000', '15918000');

-- ----------------------------
-- Table structure for dondathang
-- ----------------------------
DROP TABLE IF EXISTS dondathang;
CREATE TABLE dondathang (
  MaDonDatHang int IDENTITY(1,1) primary key not null,
  NgayLap datetime NOT NULL,
  MaTK varchar(255) ,
  TongThanhTien varchar(255) ,
  
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of dondathang
-- ----------------------------
INSERT INTO dondathang VALUES ('1', '2016-12-31 18:26:15', '7', '209408000');
INSERT INTO dondathang VALUES ('2', '2016-12-31 18:26:51', '7', '209408000');
INSERT INTO dondathang VALUES ('3', '2016-12-31 18:29:39', '7', '13500000');
INSERT INTO dondathang VALUES ('4', '2016-12-31 18:42:14', '7', '13500000');
INSERT INTO dondathang VALUES ('5', '2016-12-31 18:42:29', '7', '43176000');
INSERT INTO dondathang VALUES ('6', '2016-12-31 19:02:05', '7', '99196000');
INSERT INTO dondathang VALUES ('7', '2016-12-31 19:07:44', '7', '99196000');
INSERT INTO dondathang VALUES ('8', '2016-12-31 19:08:01', '7', '99196000');
INSERT INTO dondathang VALUES ('9', '2016-12-31 19:08:42', '7', '99196000');
INSERT INTO dondathang VALUES ('10', '2016-12-31 19:10:56', '7', '99196000');
INSERT INTO dondathang VALUES ('11', '2016-12-31 19:11:00', '7', '99196000');
INSERT INTO dondathang VALUES ('12', '2017-01-02 12:06:05', '4', '59208000');
INSERT INTO dondathang VALUES ('13', '2017-01-02 12:06:46', '4', '59208000');

-- ----------------------------
-- Table structure for hangsx
-- ----------------------------
DROP TABLE IF EXISTS hangsx;
CREATE TABLE hangsx (
  MaHangSX int NOT NULL AUTO_INCREMENT,
  TenHangSX varchar(50) ,
  PRIMARY KEY (MaHangSX)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of hangsx
-- ----------------------------
INSERT INTO hangsx VALUES ('1', 'Fujifilm');
INSERT INTO hangsx VALUES ('2', 'Sony ');
INSERT INTO hangsx VALUES ('3', 'Canon ');
INSERT INTO hangsx VALUES ('4', 'Nikon ');
INSERT INTO hangsx VALUES ('5', 'Olympus ');
INSERT INTO hangsx VALUES ('6', 'Panasonic ');
INSERT INTO hangsx VALUES ('7', 'Khác');

-- ----------------------------
-- Table structure for loaisanpham
-- ----------------------------
DROP TABLE IF EXISTS loaisanpham;
CREATE TABLE loaisanpham (
  MaLoaiSP int NOT NULL AUTO_INCREMENT,
  TenLoaiSP varchar(50) COLLATE utf8_unicode_ci ,
  PRIMARY KEY (MaLoaiSP)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of loaisanpham
-- ----------------------------
INSERT INTO loaisanpham VALUES ('1', 'Máy ảnh không gương lật');
INSERT INTO loaisanpham VALUES ('2', 'Máy ảnh DSLR');
INSERT INTO loaisanpham VALUES ('3', 'Máy Ảnh Số Du Lịch');
INSERT INTO loaisanpham VALUES ('4', 'Máy Ảnh chụp lấy ngay');
INSERT INTO loaisanpham VALUES ('5', 'Máy Ảnh MINI');
INSERT INTO loaisanpham VALUES ('6', 'Khác');

-- ----------------------------
-- Table structure for sanpham
-- ----------------------------
DROP TABLE IF EXISTS sanpham;
CREATE TABLE sanpham (
  MaSP int NOT NULL AUTO_INCREMENT,
  TenSP varchar(50) COLLATE utf8_unicode_ci ,
  GiaSP int ,
  SoLuotXem int ,
  SoLuongBan int ,
  NgayNhap datetime ,
  MoTa text COLLATE utf8_unicode_ci,
  ChiTiet text COLLATE utf8_unicode_ci,
  XuatXu varchar(50) COLLATE utf8_unicode_ci ,
  MaLoaiSP int ,
  MaHangSX int ,
  PRIMARY KEY (MaSP)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of sanpham
-- ----------------------------
INSERT INTO sanpham VALUES ('1', 'Fujifilm X-A2', '10924000', '0', '1', '2016-12-12 00:15:11', 'Nhỏ gọn với khả năng vượt trội, thỏa sức sáng tạo', '<UL><LI>Cảm biến 16.3MP APS-C CMOS</LI><LI>Quay phim Full HD 1080p 30 fps</LI><LI>Màn hình 3.0” LCD xoay 175°</LI><LI>Chụp macro ở khoảng cách 15cm</LI><LI>AF nhận diện mắt; AF chụp Macro Tự động và AF đa điểm</LI><LI>Dung lượng pin cực lớn chụp tới 410 bức ảnh</LI><LI>Hệ thống chống rung ảnh 3 đến 3.5 điểm dừng</LI><LI>ISO 25600</LI></UL>', 'Thái Lan', '1', '1');
INSERT INTO sanpham VALUES ('2', 'Fujifilm X-T10', '22390000', '0', '4', '2016-12-06 00:15:36', ' thiết kế đẹp mắt,Độc đáo', '<UL><LI>Cảm biến APS-C X-Trans CMOS II 16.3 MP , Tích hợp Pop-Up Flash</LI><LI>Màn hình LCD lật 3.0 inch 920.000 điểm </LI><LI>Quay phim Full HD 1080p tại 60 fps</LI><LI>Chế độ lấy nét tự động thông minh 77 khu vực</LI><LI>Chụp 8 hình/giây and ISO 51200, hỗ trợ kết nối  Wi-Fi </LI></UL>', 'Nhật Bản', '1', '1');
INSERT INTO sanpham VALUES ('3', 'Sony Alpha ILCE-6000L', '13500000', '1', '5', '2016-11-02 00:15:43', 'Thiết kế đọc đáo, hình ảnh chất lương cao', '<UL><LI>Kích thước màn hình 3 inch,  Độ phân giải camera 24,3 MP,  Loại màn hình TFT LCD</LI><LI>Kích thước sản phẩm 14.5x13x15.5, Độ nhạy sáng ISO Auto – 25600</LI><LI>Cổng kết nối Mass-storage, MTP, PC remote, HDMI micro (Type-D)</LI><LI>Bộ xử lý BIONZ cho tốc độ xử lý nhanh</LI></UL>', 'Nhật Bản', '1', '2');
INSERT INTO sanpham VALUES ('4', 'mirrorless Canon EOS M3', '10390000', '1', '25', '2016-11-06 00:16:13', 'Cảm biến và bộ xử lý hình ảnh cao cấp', '<UL><LI>Cảm biến CMOS APS-C 24.2MP</LI><LI>Cảm biến hình ảnh DIGIC 6</LI><LI>Màn hình cảm ứng LCD 3.0 inch 1.040k-Dot</LI><LI>Quay phim Full HD 1080p tại 24/24/30fps</LI><LI>Tích hợp kết nối NFC và Wifi</LI><LI>Công nghệ lấy nét Hybrid CMOS AF với 49 điểm</LI><LI>ISO 100-12800; mở rộng 25600</LI></UL>', 'Nhật Bản', '1', '3');
INSERT INTO sanpham VALUES ('5', 'Nikon 1 J2', '6900000', '5', '14', '2016-11-17 00:15:52', 'Nhỏ gọn đày nữ tính', '<UL><LI>Kích thước màn hình 3 inch, Độ phân giải camera 10 MP</LI><LI>Kích thước sản phẩm (D x R x C cm) 15x8x16, Zoom quang 1.0</LI><LI>[ Chế độ Chọn Ảnh Thông minh ] Bắt đầu chụp trước khi nhấn cửa trập</LI><LI>Quay phim Full HD 1080p tại 24/24/30fps</LI><LI>[ Full HD ] Tận hưởng khả năng quay phim Full HD</LI><LI>Đèn nháy gắn sẵn </LI><LI>Bật/tắt với thấu kính có thể thu lại</LI></UL>', 'Nhật Bản', '1', '4');
INSERT INTO sanpham VALUES ('6', 'Olympus PEN mini E-PM2', '12029000', '0', '13', '2016-11-06 00:16:00', 'Hình ảnh chất lượng cao, Lấy nét chỉ bằng động tác chạm ngón tay', '<UL><LI>Độ phân giải camera  16.1MP</LI><LI>Cảm biến 4/3 Live MOS Sensor</LI><LI>Lens M.ZUIKO 14-42mm, Độ nhạy sáng ISO 200 – 25600</LI><LI>Màn hình 3” LCD, Mẫu mã E-PM2-1442-2RK(G)RED/SLV</LI><LI>Trọng lượng 0.325 kg</LI></UL>', 'Việt Nam', '1', '5');
INSERT INTO sanpham VALUES ('7', 'Olympus PEN E-PM2', '10359000', '0', '14', '2016-11-02 00:16:07', 'Quay phim HD, giảm rung và chống bám bẩn', '<UL><LI>Màn hình cảm ứng 3.0 inch, Độ phân giải camera 16 MP</LI><LI>Lấy nét nhanh chóng từ màn hình, Chất lượng hình ảnh 4608 x 3456</LI><LI>Kích thước sản phẩm  0.325 x 24.5 x 10  (D x R x C cm)</LI><LI>Độ nhạy sáng ISO 200 – 26500</LI><LI>Trọng lượng 0.325 kg</LI></UL>', 'Trung quốc', '1', '5');
INSERT INTO sanpham VALUES ('8', 'Nikon J3', '7959000', '1', '34', '2016-07-05 00:16:23', 'Thiết kế cao cấp, Kiểu dáng nhỏ gọn và nhiều màu sắc đa dạng', '<UL><LI>Cảm biến 1\" CX-CMOS độ phân giải 14.2 Megapixels</LI><LI>Tốc độ chụp liên tiếp 10 hình/giây khi lấy nét tự động</LI><LI>Bộ xử lý ảnh EXPEED 3 - ISO 160-6400</LI><LI>Quay phim Full-HD 1080p với âm thanh Stereo</LI><LI>Màn hình siêu nét 3” độ phân giải 921K điểm ảnh</LI><LI>Sản phẩm mới 100%; Giá gồm VAT</LI></UL>', 'Trung quốc', '1', '4');
INSERT INTO sanpham VALUES ('9', 'Panasonic Lumix DMC-GH4 body  ', '42000000', '3', '23', '2016-01-11 00:16:30', 'đẹp , bền, có khả nang chống nước, chống bụi', '<UL><LI>Cảm biến Live-MOS 16-Mpix </LI><LI>Chụp liên tục 12 khung hình/giây khi lấy nét đơn (AF-S) </LI><LI>Hệ thống lấy nét tự động theo tương phản 49 điểm</LI><LI>Màn hình OLED sau lật xoay 3.0 inch 1.03 triệu điểm ảnh</LI><LI>Quay phim DCI 4K (4096 x 2160) 24p</LI><LI>Quay phim UHD 4K 3840 x 2160 30/24p</LI><LI>Quay phim Full HD lên tới 60p</LI><LI>Đầu ra HDMI 4:2:2 8-Bit hoặc 10-Bit </LI></UL>', 'Trung quốc', '1', '6');
INSERT INTO sanpham VALUES ('10', 'Canon EOS 700D', '9850000', '0', '20', '2016-05-09 00:16:38', 'Thiết kế mới , tinh sảo', '<UL><LI>Kích thước màn hình 3inch, Có Ống kính đi kèm(18-55 STM) </LI><LI>Độ phân giải camera   18 Megapixels,Loại pin: Li-ion</LI><LI>SensorType: CMOS, Kích thước sản phẩm 13.2 x 9.9x 7.9 (D x R x C cm)</LI><LI>LensModel: Lens EF-S 18-55mm IS STM</LI><LI>LensKit: Có,CameraAddAcc: Thẻ nhớ 8GB</LI></UL>', 'Đài Loan', '2', '3');
INSERT INTO sanpham VALUES ('11', 'Canon EOS 70D', '19200000', '0', '33', '2016-09-29 00:16:44', 'Giá rẻ với nhiều tính năng hấp dẫn', '<UL><LI>Cảm biến CMOS 20.2 MP kích thước APS-C</LI><LI>Đóng nhãn hiệu: Torrini</LI><LI>Bộ xử lý hình ảnh: DIGIC 5+</LI><LI>Màn hình LCD ClearView II 3inch</LI><LI>ISO 100-12.800 (mở rộng 25.600), quay phim tối đa 6.400</LI><LI>Hỗ trợ kết nối Wi-Fi</LI><LI>Hệ thống lấy nét Dual pixel AF 19 điểm</LI><LI>Tốc độ chụp 7 fps</LI><LI>Quay phim Full HD 1920 x 1080 pixel</LI></UL>\r\n<UL><LI>Cảm biến CMOS 20.2 MP kích thước APS-C</LI><LI>Đóng nhãn hiệu: Torrini</LI><LI>Bộ xử lý hình ảnh: DIGIC 5+</LI><LI>Màn hình LCD ClearView II 3inch</LI><LI>ISO 100-12.800 (mở rộng 25.600), quay phim tối đa 6.400</LI><LI>Hỗ trợ kết nối Wi-Fi</LI><LI>Hệ thống lấy nét Dual pixel AF 19 điểm</LI><LI>Tốc độ chụp 7 fps</LI><LI>Quay phim Full HD 1920 x 1080 pixel</LI></UL>', 'Nhật Bản', '2', '3');
INSERT INTO sanpham VALUES ('12', 'Sony SLT-A57K', '15990000', '0', '12', '2016-02-08 00:16:51', 'Thiết kế mạnh mẽ, cá tính', '<UL><LI>Loại ống kính: 18 - 55mm f3.5 - 5.6 , Độ phân giải 16.1 Mega Pixels</LI><LI>Độ lớn màn hình LCD (inch), Màn hình xoay lật 3.0\" Clear Photo LCD</LI><LI>Bộ cảm biến hình ảnh: APS-C HD CMOS, Độ nhạy sáng: ISO 16000</LI><LI>Tốc độ màn trập 1/4000 - 30s, digital Zoom Zoom kỹ thuật số rõ nét với Clear Image Zoom</LI><LI>Loại pin sử dụng: Pin Stamina có thời lượng sử dụng cao, quay phim: Chuẩn Full HD</LI><LI>Bộ nhớ trong: (Mb) Sử dụng thẻ MS và SD</LI><LI>Chụp quét toàn cảnh với 3D SWEEP PANORAMA</LI><LI>Đa dạng màu sắc với chức năng Picture Effect</LI></UL>', 'Nhật Bản', '2', '2');
INSERT INTO sanpham VALUES ('13', 'Sony A77 Mark II', '24289000', '0', '23', '2016-02-02 00:17:05', 'Kính ngắm điện tử độ phân giải cao XGA OLED, Nhiều hiệu ứng hình ảnh sáng tạo', '<UL><LI>Cảm biến Exmor CMOS 24.3MP</LI><LI>Màn hình xoay 3 chiều 3.0” OLED Tru-Finder</LI><LI>Quay phim Full HD</LI><LI>Hệ thống lấy nét 79 điểm</LI><LI>Vi xử lý BIONZ tiên tiến</LI><LI>Công nghệ gương mờ Translucent Mirror lấy nét nhanh và chính xác</LI><LI>Kết nối Wifi, NFC tích hợp</LI></UL>', 'Nhật Bản', '2', '2');
INSERT INTO sanpham VALUES ('14', 'Nikon D7200', '24090000', '0', '12', '2016-03-01 00:17:12', 'chụp ảnh tốc độ cao kéo dài, sắc nét ngay cả trong điều kiện ánh sáng yếu', '<UL><LI>Cảm biến ảnh: CMOS 24.2 MP. DX format. kích thước APS-C</LI><LI>Bộ xử lý hình ảnh: EXPEED 4</LI><LI>Bộ chuyển tín hiệu A/D: 14-bit. 12-bit</LI><LI>Màn hình: LCD 3.2\" độ phân giải 1.228.800 điểm ảnh</LI><LI>ISO: 25.600. tối ưu 100 - 6.400. mở rộng 102.800 với ảnh đen trắng</LI><LI>Hệ thống lấy nét: 51 điểm. 15 điểm cross-type</LI><LI>Quay phim: 1.920 x 1.080 pixel</LI><LI>Chụp liên tiếp: 6 fps</LI></UL>', 'Thái Lan', '2', '4');
INSERT INTO sanpham VALUES ('15', 'Nikon D750', '36000000', '0', '23', '2016-04-29 00:17:21', 'Tính Năng nổi bật, hình ảnh sắt nét', '<UL><LI>Màn hình RGB 3.2-inch;,1.2 triệu điểm ảnh hỗ trợ lật xoay nghiêng</LI><LI>Độ phân giải camera 24.3 MP, Kích thước màn hình 3 inch</LI><LI>Kích thước sản phẩm 40x40x25 (D x R x C cm), Trọng lượng 0.9  (KG)</LI><LI>Loại pin/ác quy Removable Rechargeable Battery</LI></UL>', 'Thái Lan', '2', '4');
INSERT INTO sanpham VALUES ('16', 'KTS Fujifilm FinePix S9900W', '6800000', '0', '5', '2016-12-05 00:17:28', 'lý tưởng cho người dùng yêu thích chụp ảnh hoàng hôn', '<UL><LI>Ống kính siêu zoom 50x (24mm-1200mm)</LI><LI>Ống kính zoom quang FUJINON có khẩu độ F2.9 – F6.5 sẽ giảm tối đa hiện tượng </LI><LI>Ống kính có tiêu cự (24mm-1200mm) cho khả năng zoom lên đến 50x </LI><LI>Kính ngắm EVF và cảm biến BSI-CMOS 16.2MP</LI><LI>Quay phim Full HD 1080i/60fps</LI><LI>Kích thước sản phẩm 12.26 x 8.69 x 11.62 (D x R x C cm)</LI><LI>Chụp ảnh thông minh, chụp ảnh từ xa và chỉ sẻ tức thì</LI></UL>', 'Trung Quốc', '2', '1');
INSERT INTO sanpham VALUES ('17', 'Canon EOS 6D Wifi', '40490000', '0', '3', '2016-10-11 00:17:34', 'Vỏ thiết kế chống nước, bụi bặm', '<UL><LI>Cảm biến Full-Frame CMOS 20.2MP</LI><LI>Bộ xử lý ảnh DIGIC 5+</LI><LI>Màn hình LCD Clear View 3.0\" 1.04m-Dot</LI><LI>Quay phim Full HD 1080p 30fps</LI><LI>Tích hợp Wifi và GPS</LI><LI>Hỗ trợ lấy nét tự động 11 điểm</LI><LI>Chụp ảnh liên tục 4.5 fps</LI></UL>', 'Nhật Bản', '2', '3');
INSERT INTO sanpham VALUES ('18', 'Compact Fujifilm XF1 (Nâu)', '7900000', '1', '2', '2016-05-29 00:17:42', 'Thiết kế quyến rũ tinh tế mang phong cách cổ điển', '<UL><LI>Cảm biến EXR CMOS 2/3\" độ phân giải 12.0 Mps</LI><LI>Ống kính Fujinon 25-100mm độ mở lớn tới f1.8</LI><LI>Tốc độ chụp liên tục lên tới 10 hình/s, ISO tới 12.800</LI><LI>Hỗ trợ định dạng RAW với các chế độ chuyên nghiệp</LI><LI>Quay phim FullHD 1920*1080, chụp Panorama 360°</LI><LI>Hỗ trợ lấy nét tự động 11 điểm</LI></UL>', 'Trung Quốc', '3', '1');
INSERT INTO sanpham VALUES ('19', 'Olympus Stylus TG-4 Tough', '7288000', '0', '5', '2016-12-07 00:17:51', 'Nhỏ gọn, năng động', '<UL><LI>Cảm biến BSI CMOS 1/2.3\" 16 triệu điểm ảnh</LI><LI>Chống nước với độ sâu tới 15m (sẽ được gia tăng lên 45m với bộ giáp lặn PT-056) </LI><LI>Chống băng giá với nhiệt độ xuống tới -10 độ C</LI><LI>Chống lực đè nén lên tới 100kg</LI><LI>Chống sốc với độ cao 2.1m </LI><LI>Ống kính siêu nhanh f/2.0 với dải zoom rộng: 25-100mm (quy chuẩn 35mm) f/2.0-4.9</LI><LI>Màn hình lớn 3 inch với tấm nền bảo vệ chắc chắn</LI><LI>ISO 100-6400 và chụp ảnh liên tiếp 5 hình/giây </LI><LI>Hỗ trợ chụp ảnh RAW, quay phim Full HD</LI></UL>', 'Việt Nam', '3', '5');
INSERT INTO sanpham VALUES ('20', 'Olympus Stylus 1', '15948000', '2', '7', '2016-01-02 00:17:56', 'Thiết kế tinh sảo, chắc chắn', '<UL><LI>Cảm biến CMOS 1/1.7\" 12MP</LI><LI>Định dạng ảnh: JPEG, RAW</LI><LI>Định dạng video: MJPEG, MOV, MPEG-4 AVC/H.264</LI><LI>Định dạng âm thanh: Linear PCM (Stereo)</LI><LI>Tiêu cự: 6.0-64.3 mm (tương đương 28-300 mm trên máy full-frame) </LI><LI>Tốc độ màn trập 60 - 1/2000 seconds</LI></UL>', 'Nhật Bản', '3', '5');
INSERT INTO sanpham VALUES ('21', 'Canon EOS M10', '7290000', '1', '9', '2016-11-08 00:18:07', 'Nhỏ gon, thân thiện với người dùng', '<UL><LI>Độ phân giải 18 Megapixel</LI><LI>Tiêu cự 24-600mm</LI><LI>Hệ thống zoom zoom quang học 25x</LI><LI>Bộ xử lý ảnh DIGIC 6</LI><LI>Màn hình LCD cảm ứng điện dung 3.2 inch </LI><LI>Tốc độ ISO ISO 12012.800 auto</LI><LI>Nguồn điện Bộ pin NB-10L</LI><LI>Quay Phim Full HD 60p, MP4, chống rung</LI></UL>', 'Nhật Bản', '3', '3');
INSERT INTO sanpham VALUES ('22', 'Panasonic DMC-LX100', '19668000', '0', '11', '2016-09-13 00:18:16', 'bộ xử lý hình ảnh Venus Engine thế hệ mới, nhỏ gọn, trọng lượng nhẹ', '<UL><LI>Chụp ảnh rõ nét với cảm biến CMOS 12.8MP 1, zoom quang 3.1x</LI><LI>HĐộ nhạy sáng  ISO 200-25600</LI><LI>Quay phim Full HD</LI><LI>Màn hình LCD 3 inch sắc nét, Kích thước sản phẩm 12 x 7 x 6 (D x R x C cm)</LI><LI>Kết nối Wi-Fi</LI><LI>Nguồn điện Bộ pin NB-10L</LI><LI>Quay Phim Full HD 60p, MP4, chống rung</LI></UL>', 'Trugn Quốc', '3', '6');
INSERT INTO sanpham VALUES ('23', 'KTS Panasonic lDMC-LX7 Lumix', '9500000', '0', '12', '2016-05-07 00:18:26', 'Trang bị thêm nhiều tính năng hiện đại, Thiết kế nhỏ gọn, tiện lợi', '<UL><LI>Độ phân giải 10.1 MPXs</LI><LI>Góc chụp siêu rộng 24mm</LI><LI>Ống kính LEICA DC VARIO-SUMMICRON 3.8x độ mở F2.0</LI><LI>Bộ xử lý ảnh tiên tiến Venus Engine thế hệ IV</LI><LI>Độ nhạy sáng ISO lên tới 12.800, chụp Macro 1cm</LI><LI>Quay phim HD chất lượng cao âm thanh Stereo</LI><LI>Màn hình 3 inch, độ phân giải tới 460.000 điểm ảnh </LI></UL>', 'Nhật Bản', '3', '6');
INSERT INTO sanpham VALUES ('24', 'KTS Olympus Tough TG-2', '11000000', '5', '9', '2016-12-08 00:18:38', 'Thiết kế ấn tượng, Hình ảnh chat lượng cao, rõ nét', '<UL><LI>Độ phân giải camera 12(MP), Kích thước sản phẩm 13.5x 10.7x 14.9 (D x R x C cm)</LI><LI>Zoom quang 4x</LI><LI>Màn hình LCD 3.0 inch</LI><LI>Pin Lithium-Ion LI90B</LI><LI>Chụp dưới nước tối đa 15m</LI><LI>độ phân giải tới 460.000 điểm ảnh </LI></UL>', 'Nhật Bản', '3', '5');
INSERT INTO sanpham VALUES ('25', 'Fujifilm Instax Wide 300 (Đen)', '3350000', '2', '18', '2016-06-04 00:18:42', 'Chụp lấy ngay, tiện lợi dễ sử dụng', '<UL><LI>Kích thước ảnh: 99mm x 62mm, Đóng mở ống kính Fujino, 2 bộ phận, 2 cấu trúc, f = 95mm, F = 14</LI><LI>Chế độ Bình thường: 0.9 ~ 3m – Chế độ phong cảnh: 3m ~ ∞, Màn trập điện tử được lập trình, 1/64 ~ 1/200 giây</LI><LI>pin AA x 4,Kích thước: 94,5 H x 178.5 W 117,5 D ( mm),Trọng lượng (chỉ tính thân máy): 612g</LI><LI>Kích thước sản phẩm (D x R x C cm)  là 11.75 x 17.85 x 9.45</LI><LI>Trọng lượng 0.275 kg</LI><LI>gương phản chiếu xinh xắn ở mặt,độ nhạy sáng ISO Auto / 100 / 1600 / 200 / 3200 / 400 / 800</LI></UL>', 'Trung Quốc', '4', '1');
INSERT INTO sanpham VALUES ('26', 'Fujifilm Instax Mini 50s (Đen)', '3350000', '0', '5', '2016-05-05 00:18:50', 'Tinh tế và hoài cổ', '<UL><LI>Độ phân giải camera 1.5 MP</LI><LI>Chế độ Bình thường: 0.9 ~ 3m – Chế độ phong cảnh: 3m ~ ∞, Màn trập điện tử được lập trình, 1/64 ~ 1/200 giây</LI><LI>pin AA x 4,Kích thước: 94,5 H x 178.5 W 117,5 D ( mm),Trọng lượng (chỉ tính thân máy): 612g</LI><LI>Kích thước sản phẩm (D x R x C cm)  là 11.75 x 17.85 x 9.45.</LI></UL>', 'Trung Quốc', '4', '1');
INSERT INTO sanpham VALUES ('27', 'Fujifilm Instax mini 8', '1890000', '0', '7', '2016-10-03 00:18:58', 'Lấy hình ngay trong nhích nháy, Thiết kế trẻ trung và độc lạ', '<UL><LI>Kích thước ảnh 62x46mm</LI><LI>Model: Instax Mini 8 </LI><LI>Kích thước ảnh 62x46mm</LI><LI>Sử dụng pin AA</LI></UL>', 'Trung Quốc', '4', '1');
INSERT INTO sanpham VALUES ('28', 'Mini DV Recorder', '219000', '2', '4', '2016-08-12 00:19:09', 'Cực Nhỏ , với kích thước gọn đến không ngờ, tích hợp đủ chức năng', '<UL><LI>Độ phân giải : VGA 1280 * 960. 29fps</LI><LI>Hình ảnh độ phân giải: 5 MP</LI><LI>Độ phân giải webcam: 320 * 240</LI><LI>Ống kính góc: 60 độ</LI><LI>Chức năng phát hiện chuyển động video</LI><LI>Định dạng: AVI (video); JPG (ảnh); WAV (âm thanh)</LI></UL>', 'Hồng Công', '5', '7');
INSERT INTO sanpham VALUES ('29', 'ASOCA002K', '1570000', '0', '3', '2016-02-04 00:19:17', 'Nhỏ , gọn, nhẹ', '<UL><LI>Chụp ảnh 16 mega pixels (16MP)</LI><LI>Màn hình hiển thị TFT LCD 2.7inch</LI><LI>Thẻ nhớ SD, MMC, hỗ trợ dung lượng lên đến 32GB</LI><LI>Chống rung, tự động nhận diện khuôn mặt, chụp nụ cười, chụp paranoma, pin sạc (BL-4C) qua cáp USB</LI><LI>Định dạng: AVI (video); JPG (ảnh); WAV (âm thanh)</LI></UL>', 'Trung quốc', '5', '7');
INSERT INTO sanpham VALUES ('30', 'Fujifilm Instax Mini 70', '3660000', '0', '7', '2016-03-03 00:19:24', 'Thiết kế thời trang,sành điệu phù hợp với giới trẻ', '<UL><LI>Kích cỡ ảnh: 62 x 46 mm</LI><LI>Tích hợp đèn Flash</LI><LI>Pin: CR2/DL CR2 Lithium</LI></UL>', 'Trung Quốc', '5', '1');
INSERT INTO sanpham VALUES ('31', 'Canon PowerShot SX420 IS', '4950000', '4', '8', '2016-12-02 00:19:34', 'Gọn, phù hợp với các chuyến đi xa', '<UL><LI>Độ lớn màn hình LCD (inch): 3.0 inch</LI><LI>Megapixel (Số điểm ảnh hiệu dụng): 20 Megapixel</LI><LI>Độ phân giải ảnh lớn nhất: 5152 x 3864</LI><LI>Optical Zoom (Zoom quang): 42x</LI><LI>Digital Zoom (Zoom số): 4.0x</LI><LI>Tính năng: Wifi, Nhận dạng khuôn mặt, Voice Recording, Quay phim HD Ready</LI></UL>', 'Nhật Bản', '3', '3');
INSERT INTO sanpham VALUES ('32', 'KTS NiKonCoolpix L840', '6500000', '0', '5', '2016-07-29 00:19:38', 'Kiểu dáng mới lạ,đẹp mắt', '<UL><LI>DisplaySize: 3</LI><LI>OpticalZoom: 38</LI><LI>Độ phân giải ảnh 16 Megapixels</LI><LI>BatteryType: alkaline LR6/L40</LI></UL>', 'Trung Quốc', '3', '4');
INSERT INTO sanpham VALUES ('33', 'Samsung camera 2 GC200', '4500000', '0', '5', '2017-01-12 23:33:07', 'nhỏ gọn, xinh xắn', '<ul><li>Hệ điều hành Android 4.3 tiên tiến</li><li>Kết nối wifi và NFC cực nhanh</li><li>cho phép thu hình với chất lượng tối đa Full HD 1.080p tốc độ 30 hình mỗi giây</li><li>kích thước 4.8 inch, có độ phân giải 720p sử dụng công nghệ LCD</li></ul>', 'Trung Quốc', '5', '7');
INSERT INTO sanpham VALUES ('34', 'HD VIDEO RECORDER - PK19-234', '230000', '0', '4', '2017-01-12 23:51:50', 'thiết kế mới, lạ mắt', '<ul><li>Độ phân giải: 720 x 480 (chuẩn DVD)</li><li>Tốc độ quay: 30 fps</li><li>Định dạng video: AVI</li><li>Thẻ nhớ: MicroSD, dung lượng tối đa: 8G</li><li>Thời lượng quay: 2h</li></ul>', 'Việt Nam', '5', '7');
INSERT INTO sanpham VALUES ('35', 'Polaroid', '3900000', '0', '7', '2017-01-12 23:56:25', 'Trẻ trung, khoe cá tính', '<ul><li>Độ phân giải: 720 x 480 (chuẩn DVD)</li><li>Máy ảnh lấy hình tức khắcPolaroid Z2300 10MP Digital Instant Print Camera – Black</li><li>Định dạng video: AVI</li><li>Thẻ nhớ: MicroSD, dung lượng tối đa: 8G</li><li>Polaroid ZIP Mobile Printer w/ZINK Zero Ink Printing Technology – Compatible w/iOS & Android Devices</li></ul>', 'Trung Quốc', '4', '7');
INSERT INTO sanpham VALUES ('36', 'KTS Webvision L29', '699000', '0', '4', '2017-01-12 23:58:49', 'Nhỏ nhắn, tiện lợi,Dễ sử dụng', '<ul><li>Màn hình 2.7 inch,Độ phân giải 18MP</li><li>Zoom quang 8x,Pin sạc Lithium</li><li>Chế độ chống sốc</li><li>Thẻ nhớ: MicroSD, dung lượng tối đa: 8G</li><li>Compatible w/iOS & Android Devices</li></ul>', 'Thái Lan', '5', '7');
INSERT INTO sanpham VALUES ('37', 'SKT Canon Powershot G9X', '5690000', '0', '4', '2017-01-13 00:03:41', 'Thỏa sức khám phá', '<ul><li>Màn hình 2.7 inch,Độ phân giải 18MP</li><li>Cảm biến BSI-CMOS 20.2MP</li><li>Chế độ chống sốc,Quay video Full HD</li><li>Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L</li><li>Compatible w/iOS & Android Devices</li></ul>', 'Nhật Bản', '3', '3');
INSERT INTO sanpham VALUES ('38', ' Duble Screen HD', '1351000', '0', '3', '2017-01-13 00:05:55', 'Thiết kế thân máy mỏng nhẹ và thời trang', '<ul><li>Cảm biến BSI-CMOS 20.2MP</li><li>Cảm biến BSI-CMOS 20.2MP</li><li>Quay phim HD chất lượng cao âm thanh Stereo</LI><LI>Màn hình 3 inch, độ phân giải tới 460.000 điểm ảnh </li><li>Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L</li><li>Compatible w/iOS & Android Devices</li></ul>', 'Việt Nam', '5', '7');
INSERT INTO sanpham VALUES ('39', 'SONY DSC-WX350/WCE32', '5190000', '1', '2', '2017-01-13 00:10:20', 'Nhỏ gọn,Tinh tế', '<ul><li>Thiết kế hiện đại với ngoại hình nhỏ gọn, thuận tiện để bạn mang theo bên mình</li><li>Độ phân giải 18.2 MP đem đến hình ảnh chất lượng cao, rõ ràng đến từng chi tiết</li><li>Quay phim HD chất lượng cao âm thanh Stereo</LI><LI>Nhiều chế độ chụp thú vị, tạo nên phong cách riêng của bạn</li><li>Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L</li></ul>', 'Thái Lan', '3', '2');
INSERT INTO sanpham VALUES ('40', 'PowerShot D30', '7500000', '2', '3', '2017-01-13 00:17:06', 'Chống nước ở độ sâu lớn nhất', '<ul><li>Được thiết kế lớn hơn để người dùng dễ dàng sử dụng ngay cả khi đeo bao tay</li><li>Độ phân giải 18.2 MP đem đến hình ảnh chất lượng cao, rõ ràng đến từng chi tiết</li><li>Màn hình LCD được nâng cấp với chế độ Sunlight</LI><LI>Cho phép nhìn dễ dàng ngay cả dưới ánh sáng mặt trời</li><li>Độ nhạy sáng ISO 125 – 12800,Bộ pin NB-13L</li></ul>', 'Nhật Bản', '5', '3');

-- ----------------------------
-- Table structure for taikhoan
-- ----------------------------
DROP TABLE IF EXISTS taikhoan;
CREATE TABLE taikhoan (
  MaTK int NOT NULL AUTO_INCREMENT,
  TenDN varchar(50) COLLATE utf8_unicode_ci ,
  MatKhau varchar(50) COLLATE utf8_unicode_ci ,
  HoTen varchar(50) COLLATE utf8_unicode_ci ,
  Email varchar(256) COLLATE utf8_unicode_ci ,
  DOB varchar(11) COLLATE utf8_unicode_ci ,
  MaLoaiTK int ,
  PRIMARY KEY (MaTK)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of taikhoan
-- ----------------------------
INSERT INTO taikhoan VALUES ('25', 'a', '202cb962ac59075b964b07152d234b70', 'hauhero', 'hotdau911995@gmail.com', '2017-01-30 ', '0');
INSERT INTO taikhoan VALUES ('26', 'q', '202cb962ac59075b964b07152d234b70', 'hauhero', 'hotdau911995@gmail.com', '2017-01-17 ', '0');
INSERT INTO taikhoan VALUES ('27', 'z', '', 'hauhero', 'hotdau911995@gmail.com', '2017-01-31 ', '0');
INSERT INTO taikhoan VALUES ('28', 'z', '123', 'trương văn hau', 'hotdau911995@gmail.com', '2017-01-30 ', '0');
INSERT INTO taikhoan VALUES ('30', 'd', '698d51a19d8a121ce581499d7b701668', 'hauhero', 'hotdau911995@gmail.com', '2016-12-25 ', '0');
