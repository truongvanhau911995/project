<?php 
    include_once '../connect.php';
    session_start();
    $maTaiKhoan = $_SESSION["MaTaiKhoan"];
    $arrCharacter = array_merge(range('A','Z'), range('a','z'), range(0,9));
    $arrCharacter = implode($arrCharacter, '');
    $arrCharacter = str_shuffle($arrCharacter);    
    $maDonDatHang = substr($arrCharacter, 0, 4);
    date_default_timezone_set("Asia/Ho_Chi_Minh"); 
	$ngayLap = date("Y-m-d H:i:s");	
	$tongGia = $_SESSION['tongtien'];
	$maTinhTrang =1;
    $query ="INSERT INTO dondathang(MaDonDatHang, NgayLap, TongThanhTien, MaTaiKhoan, MaTinhTrang) VALUES ('$maDonDatHang','$ngayLap',$tongGia,$maTaiKhoan,$maTinhTrang)";
	//$query ="INSERT INTO dondathang(MaDonDatHang, NgayLap, TongThanhTien, MaTaiKhoan, MaTinhTrang) VALUES ('1',1233,12,1)";
	
	$database->query($query);
    $database ->redirect('../index.php?chon=thongbao');
?>