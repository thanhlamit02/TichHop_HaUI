<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="HoaDon">
		<html>
			<head>
				<title>Phiếu mua hàng</title>
			</head>
			<body>
				<h2>Phiếu mua hàng</h2>
				<span>Hóa đơn: <xsl:value-of select="MaHD"/>   
			</span>
				<span>
					Ngày bán: <xsl:value-of select="NgayBan"/>
				</span>
				<br/>
				<span>
					Loại hàng: <xsl:value-of select="LoaiHang/@TenLoai"/>
				</span>
				<table border="1" cellpadding="3">
					<tr>
						<th>Mã hàng</th>
						<th>Tên hàng</th>
						<th>Số lượng</th>
						<th>Đơn giá</th>
						<th>Thành tiền</th>
					</tr>
					<xsl:apply-templates select="LoaiHang"/>
				</table>
				<br/>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="Hang">
		<tr>
			<td align="Center">
				<xsl:value-of select="@MaHang"/>
			</td>
			<td align="Center">
				<xsl:value-of select="TenHang"/>
			</td>
			<td align="Center">
				<xsl:value-of select="SoLuong"/>
			</td>
			<td align="Center">
				<xsl:value-of select="DonGia"/>
			</td>
			<td align="Center">
				<xsl:value-of select="DonGia*SoLuong"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
