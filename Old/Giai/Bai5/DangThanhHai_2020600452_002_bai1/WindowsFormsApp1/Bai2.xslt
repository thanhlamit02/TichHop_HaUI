<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<html>
			<head>
				<title>Thông tin sinh viên</title>
			</head>
			<body>
				<table border="1">
					<tr>
						<th>STT</th>
						<th>MaSV</th>
						<th>Tên SV</th>
						<th>Giới Tính</th>
						<th>Ngày Sinh</th>
						<th>Mã lớp</th>
					</tr>
					<xsl:for-each select="Lop/SinhVien">
						<xsl:sort select="TenSv"/>
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
					</xsl:for-each>
				</table>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
