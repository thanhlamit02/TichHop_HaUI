<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="BenhVien">
		<html>
			<head>
				<title>Bệnh viên đa khoa Đông Anh</title>
			</head>
			<body>
				<p>BỆNH VIÊN ĐA KHOA</p>
				<span>
					<b>DANH SÁCH BỆNH NHÂN</b>
				</span>
				<br/>
				<span>Khoa: <xsl:value-of select="Khoa/TenKhoa"/>
			</span>
				<table border="1">
					<tr>
						<th>STT</th>
						<th>Họ tên</th>
						<th>Ngày nhập viện</th>
						<th>Số ngày điều trị</th>
						<th>Số tiền phải trả</th>
					</tr>
					<xsl:apply-templates select="Khoa/Phong/BenhNhan"/>
				</table>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="BenhNhan">
		<tr>
			<td>
				<xsl:number value="position()" format="1"/>
			</td>
			<td>
				<xsl:value-of select="HoTen"/>
			</td>
			<td>
				<xsl:value-of select="NgayNV"/>
			</td>
			<td>
				<xsl:value-of select="SoNgay"/>
			</td>
			<td>
				<xsl:value-of select="SoNgay*15000"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
