<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	<xsl:output method="html"/>

	<xsl:template match="Lop">
		<html>
			<title>Thông tin sinh viên</title>
			<table border="1" style="border-collapse: collapse" cellpadding="16px">
				<tr>
					<th>STT</th>
					<th>MaSV</th>
					<th>Tên SV</th>
					<th>Giới Tính</th>
					<th>Ngày Sinh</th>
					<th>Mã lớp</th>
				</tr>
				<xsl:apply-templates select="SinhVien">
					<xsl:sort select="TenSv"/>
				</xsl:apply-templates>
			</table>
		</html>
	</xsl:template>

	<xsl:template match="SinhVien">
		<tr>
			<td>
				<xsl:number value="position()" format="1"/>
			</td>
			<td>
				<xsl:value-of select="MaSv"/>
			</td>
			<td>
				<xsl:value-of select="TenSv"/>
			</td>
			<td>
				<xsl:value-of select="GioiTinh"/>
			</td>
			<td>
				<xsl:value-of select="NgaySinh"/>
			</td>
			<td>
				<xsl:value-of select="MaLop"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
	
