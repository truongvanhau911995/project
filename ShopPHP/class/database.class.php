<?php
	class Database{
		protected $connect;
		protected $database;
		protected $table;
		protected $resultQuery; //XUAT KET QUA KHI THUC HIEN CAU TRUY VAN
		
		public function __construct($params){// HAM XAY DUNG CLASS
			$link = mysqli_connect($params['server'], $params['username'],$params['password']);
			if(!$link){
				die('Fail connect: ' . mysqli_errno());
			}else {
			    //DANG NHAP THANH CONG
			    $this ->connect = $link;
			    $this->database = $params['database'];
			    $this->table =$params['table'];
			  
			    $this ->setDatabase();
                $this->query("SET NAMES 'utf8'");
                $this->query("SET CHARACTER SET 'utf8'");
			}
		}
		public function getConnect(){
		    return $this ->connect;
		}
		public function setConnect($connect){
		    $this ->connect = $connect;
		}
		// SET DATABASE
		public function setDatabase($database = null){
		    if($database != null){
		        $this ->database = $database;
		    }
		    mysqli_select_db($this ->connect, $this->database);// choose database to
		}
		public function getTable(){
		    return $this->table;
		}
		public function setTable($table){
		    $this->table = $table;
		}

		public function query($query){
    		 $this->resultQuery = mysqli_query($this->connect, $query);//gán câu query cho biến resultQuery
             return $this->resultQuery;
		}

		// Kiem tra du lieu khac rong
		public function checkEmpty($value){
		    $flag = false;
		    if(!isset($value) || trim($value) == ""){
		        $flag = true;
		    }
		    return $flag;
		}
		// chuyển trang
		public function redirect($url) {
		    header("HTTP/1.1 301 Moved Permanently");
		    header("Location: $url");
		}

		public function remove_cart_item($id) {// XÓA 1 SẢN PHẨM TRONG GIỎ HÀNG
		    if (!isset($_SESSION["cart"])) {
		        $_SESSION["cart"] = array();
		    }
		    for ($i=0; $i < count($_SESSION['cart']); $i++){  
		         
		        if ($_SESSION["cart"][$i]['id'] == $id) {
		             unset($_SESSION["cart"][$i]);// xóa mảng 
		            return; 
		        }
		    }
		}

		 public function update_cart_item($id, $q) {// HÀM UPDATE SỐ LƯỢNG
		    if (!isset($_SESSION["cart"])) {
		        $_SESSION["cart"] = array();
		    }
		
		    for ($i=0; $i < count($_SESSION['cart']); $i++){
		         if ($_SESSION["cart"][$i]['id'] == $id) {
		            $_SESSION["cart"][$i]['soluong'] = $q;
		            return;
		        }
		    }
		}
	}
?>