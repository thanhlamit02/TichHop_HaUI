<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="congty">
		<html>
			<head>
				<title>Bảng lương tháng 11</title>
				<link rel="stylesheet" type="text/css" href="style.css"/>
			</head>
			<body>
				<div width="100%">
					<h2 align="center">BẢNG LƯƠNG THÁNG 11-2020</h2>
					<p>
						Mã đơn vị: <xsl:value-of select="donvi/@madv"/>
					</p>
					<p>
						Tên đơn vị: <xsl:value-of select="donvi/tendv"/>
					</p>
					<p>
						Điện thoại: <xsl:value-of select="donvi/dienthoai"/>
					</p>
				</div>
				<div width="100%">
					<h3 align="center" class="title_table">DANH SÁCH NHÂN VIÊN</h3>
					<table border="1" align="center" width="60%">
						<tr>
							<th>Số TT</th>
							<th>Mã NV</th>
							<th>Họ tên</th>
							<th>Ngày sinh</th>
							<th>Hs lương</th>
							<th>Lương</th>
						</tr>
						<xsl:apply-templates select="donvi/nhanvien[hsluong >= 3]"/>
					</table>
				</div>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="nhanvien[hsluong >= 3]">
		<tr>
			<td class="so">
				<xsl:value-of select="position()"/>
			</td>
			<td class="chuoi">
				<xsl:value-of select="manv"/>
			</td>
			<td class="chuoi">
				<xsl:value-of select="hoten"/>
			</td>
			<td class="so">
				<xsl:value-of select="ngaysinh"/>
			</td>
			<td class="so">
				<xsl:value-of select="hsluong"/>
			</td>
			<td class="so">
				<xsl:value-of select="hsluong*1000"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
