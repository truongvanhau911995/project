



<?php
require_once './inc_func.php';
require_once './dbHelper.php';

if (isAuthenticated() == false) {
    
}
?>
<?php
	

if(isset($_POST["btnInsert"]))	
{
	$name=$_POST["txtName"];
	
	
	 $sql = "insert into categories (CatName) values('$name')";
        $id = save($sql, 0);
       // echo $id;
	// redirect("admin.php?act=quanlysanpham");
}	
				
				
            ?> 
<div class="col-md-9">
    <div class="panel panel-default" style="height: 324px;">
        <div class="panel-heading" style="background-color:#333;margin-bottom: 20px;">
            <h3 class="panel-title" style="color:#9d9d9d;">Thêm hãng</h3>
        </div>
		
<form class="form-horizontal" action="" method="post" id="InsertForm" onsubmit="return validate();">
		
                
                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <div class="form-group">
                            <div class="input-group">
								<span class="input-group-addon" id="basic-addon1">Tên hãng: </span>
                                <input  type="text" class="form-control" name="txtName" placeholder="Tên hãng">
                            </div>
                        </div>
                       
                    </div>
                </div>

                    <div class="col-md-10 col-md-offset-1">
                        <div class="form-group">
                            <div class="col-sm-2" style="margin-left: -25px;">
                                <button  type="submit" class="btn btn-success pull-right" name="btnInsert">
                                    <i class="fa fa-plus"></i> Thêm
                                </button>
							</div>
							<div class="col-sm-2">
								<a class="btn btn-danger" href="admin.php?act=quanlyhang" role="button">
                            <i class="fa fa-mail-reply"></i> Thoát
                        </a>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
    </div>
</div>
<?php
$js = <<<JS
<script src="assets/bootstrap-datepicker/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function validate() {
        //
        // sinh viên tự cài đặt hàm kiểm tra form
        
        return true;
    }
    
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        startDate: '-3d',
        autoclose: true,
    });
</script>
JS;
?>