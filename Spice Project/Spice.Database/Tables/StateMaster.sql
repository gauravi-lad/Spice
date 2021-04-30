CREATE TABLE [dbo].[StateMaster](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](100) NULL,
	[StateCode] [nvarchar](2) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_StateMaster] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-------------------------------------------------------------insert---------------------------------------------



insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Andaman and Nicobar Islands'	 ,'AN',getdate(),null)     
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Andhra Pradesh'            	 ,'AP',getdate(),null)     
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Arunachal Pradesh'	             ,'AR',getdate(),null)     
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Assam'                          ,'AS',getdate(),null)     
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Bihar'	                         ,'BR',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Chandigarh'	                 ,'CH',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Chhattisgarh'	                 ,'CT',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Dadra and Nagar Haveli'	     ,'DN',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Daman and Diu'	                 ,'DD',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Delhi'	                         ,'DL',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Goa'	                         ,'GA',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Gujarat'	                     ,'GJ',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Haryana'	                     ,'HR',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Himachal Pradesh'               ,'HP',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Jammu and Kashmir'	             ,'JK',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Jharkhand'	                     ,'JH',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Karnataka'	                     ,'KA',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Kerala'	                     ,'KL',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Lakshadweep'	                 ,'LD',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Madhya Pradesh'	             ,'MP',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Maharashtra'	                 ,'MH',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Manipur'	                     ,'MN',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Meghalaya'	                     ,'ML',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Mizoram'	                     ,'MZ',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Nagaland'	                     ,'NL',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Odisha'	                     ,'OR',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Puducherry'	                 ,'PD',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Punjab'	                     ,'PB',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Rajasthan'	                     ,'RJ',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Sikkim'	                     ,'SK',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Tamil Nadu'	                 ,'TN',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Telangana'                    	 ,'TS',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Tripura'	                     ,'TR',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Uttarakhand'	                 ,'UT',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Uttar Pradesh'	                 ,'UP',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'West Bengal'	                 ,'WB',getdate(),null)
insert into StateMaster(StateName,StateCode,CreatedDate,CreatedBy) values(	'Nigeria'	                     ,'NG',getdate(),null)