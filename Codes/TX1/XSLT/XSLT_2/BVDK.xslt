<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="BVDK">
		<html>
			<body>
				<div>
					<h2>BỆNH VIỆN ĐA KHOA</h2>
					<h2>DANH SÁCH BỆNH NHÂN</h2>
				</div>
				<xsl:for-each select="Khoa">
					<h4>
						Mã khoa: <xsl:value-of select="@MaKhoa"/>  
						Tên khoa: <xsl:value-of select="@TenKhoa"/>
						Phòng: <xsl:value-of select="Phong"/>
					</h4>
					<table border="1" style="border-collapse: collapse" cellpadding="20px">
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
									<xsl:value-of select="@HoTen"/>
								</td>
								<td>
									<xsl:value-of select="ThoiGian/NgayNhapVien"/>
								</td>
								<td>
									<xsl:value-of select="ThoiGian/NgayDieuTri"/>
								</td>
								<td>
									<xsl:value-of select="ThoiGian/NgayDieuTri * 150000"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</xsl:for-each>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
