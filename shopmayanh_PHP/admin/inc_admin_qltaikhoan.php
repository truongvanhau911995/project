 <?php
				
					  
					if(isset($_POST["txtDelete"])) 
					{
						$id= $_POST["txtDelete"];
						$sql = "delete  from taikhoan where Matk=$id";
						$rs = load($sql);
					}
					  $sql = "select * from taikhoan ";
					  $rs = load($sql);
 ?>		
						<form id="frmDelete" name="frmDelete" action="" method="post">
                            <input type="hidden" id="txtDelete" name="txtDelete" />
                        </form>
						
						<table class="table table-bordered">
                                <thead>
								  <tr>
									<th>Tên đăng nhập</th>
									<th>Họ tên</th>
									<th>Email</th>
									<th>DOB</th>
									<th>Mã loại tk</th>
									<th>Thao tác</th>
									
									
								  </tr>
								</thead>
							<tbody>
									<?php
										while ($row = $rs->fetch_assoc()) {
									?>
											<tr>
												<th><?php echo $row["TenDN"]; ?></th>
												<th><?php echo $row["HoTen"]; ?></th>
												<th><?php echo $row["Email"]; ?></th>
												<th><?php echo $row["DOB"]; ?></th>
												<th><?php echo $row["MaLoaiTK"]; ?></th>
												<th>
												<div class="col-sm-12">
													
													<div class="col-sm-4" style="float:left;">
														<button onclick="location.href='admin.php?act=updatetaikhoan&id=<?php echo $row['MaTK']?>'" type="submit" class="btn btn-success pull-right" name="btnUpdate">
															<i class="fa fa-check"></i> Cập Nhật
													</button>
													</div>
													<div class="col-sm-3">
													<button type="submit" class="btn btn-danger pull-right" name="btnDelete"
													        onclick="setDeleteId(<?php echo $row["MaTK"]; ?>)";>
														<i class="fa fa-mail-reply"></i> Xoá
													</button>
													</div>
												</div>
												</th>
											</tr>	
									<?php
								}
								?>
						</tbody>
					</table>
	<script type="text/javascript">	
		function setDeleteId(id) {
				document.getElementById("txtDelete").value=id;
				document.getElementById("frmDelete").submit();
			}	
</script>	
<?php
$js = <<<JS
<script src="assets/lightbox2/js/lightbox.min.js" type="text/javascript"></script>

    

JS;
?>