<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="BVDK">
		<html>
			<head>
				<title>Danh sách bệnh nhân</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<xsl:for-each select="Khoa">
					<div class="ds">
						<table width="100%" class="bang">
							<tr>
								<td>BỆNH VIÊN ĐA KHOA</td>
								<td>
									<b>DANH SÁCH BỆNH NHÂN</b>
								</td>
							</tr>
							<tr>
								<td>
									Khoa: <xsl:value-of select="TenKhoa"/>
								</td>
								<td>
									Phòng: <xsl:value-of select="Phong"/>
								</td>
							</tr>
						</table>

						<table border="1">
							<tr>
								<th>Mã số BN</th>
								<th>Họ tên</th>
								<th>Ngày nhập viện</th>
								<th>Số ngày điều trị</th>
								<th>Số tiền phải trả</th>
							</tr>
							<xsl:for-each select="BenhNhan">
								<tr>
									<td>
										<xsl:value-of select="@MasoBN"/>
									</td>
									<td>
										<xsl:value-of select="HoTen"/>
									</td>
									<td>
										<xsl:value-of select="NgayNhapVien"/>
									</td>
									<td>
										<xsl:value-of select="NgayDieuTri"/>
									</td>
									<td>
										<xsl:value-of select="NgayDieuTri * 15000"/>
									</td>
								</tr>
							</xsl:for-each>
						</table>
					</div>
				</xsl:for-each>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
