USE [Store]
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (8, N'Dota 2', 0, 0, 1, N'Valve', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (9, N'Terraria', 3, 0, 1, N'Re-Logic', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (10, N'Sifu', 10, 0, 1, N'Sloclap', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (11, N'Path Of Exile', 0, 0, 1, N'Grinding Gear Games', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (12, N'Dark Souls 3', 60, 0, 1, N'From Software', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (13, N'Dark Souls 2', 30, 0, 1, N'From Software', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (14, N'Dark Souls 1', 45, 0, 1, N'From Software', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (15, N'The Witcher ', 5, 0, 1, N'CD Project Red', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (16, N'The Witcher 2', 7, 0, 1, N'CD Project Red', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (17, N'The Witcher 3', 10, 0, 1, N'CD Project Red', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (18, N'Among Us', 1, 0, 1, N'InnerSloth', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (19, N'Grand Theft Auto 3', 15, 0, 1, N'RockStarGames', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (20, N'Grand Theft Auto 4', 10, 0, 1, N'RockStarGames', 6)
INSERT [dbo].[Games] ([Id], [Name], [Price], [Discont], [IsApproved], [Developer], [DeveloperId]) VALUES (21, N'Grand Theft Auto 5', 20, 0, 1, N'RockStarGames', 6)
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Login], [Password], [Nickname], [Balance], [Salt]) VALUES (6, N'butler', N'BdEJ+JlyCNq/xG11cfAEHhfEB6tZQp7NW5Gb6jKQpBNVxS6F1VKGfrWi0rIzPV7/Blwz6Adh7HSiuRa/n9p1DV9UnmooCUWjqRW/7DQaP/myPH9e/4i3w5VcPSz9o+86', N'butler', 69, N'0sOGCFLKJkNOAHcQD2yUPBe9DDdwZYM/m74I8Bs5/Vaf8m3DRXN0aVP1nulYH0FP8WGQnHqaSV/mRPzkdbcIpoal4uo0egxSj7fZKIKbJrPI2ZENUPkJR0lCZoZ8ggUy')
INSERT [dbo].[Users] ([Id], [Login], [Password], [Nickname], [Balance], [Salt]) VALUES (7, N'Sassiq', N'BCEAGwhoFj9tm01AEOQPLdUrWJrr+pEZ4iE5MgaMLT4mHYLUNoR0esKX7WCXnmP+HTOwBOepQlzHwBBAIm3hhy+XcK4XYcOYqF7Tp8USCy8J3vyWybKF3jmU9W93dZDB', N'Sassiq', 0, N'+CaU37tq9J71TanxN1qduCeHv26vXls2ghceXOTra5WR+n0NQsfU1FXdhASiDHzHvuEiejkewV29WVyX7ssJ9/x+YJs2zqvqFcnd7isVz/YCOGlmUG4NoIRqdPhNWQs0')
INSERT [dbo].[Users] ([Id], [Login], [Password], [Nickname], [Balance], [Salt]) VALUES (8, N'Skava', N'EXlMvdOxd2CjscO+WhynHZujwd8J9LR69WYKOvxNPIUJ+f4OGG1Qk7P0F/lE57iX6GUVhTByBvry2JRDEYAA1fAdVXZndbzJVoBjBTtuZ2W4XSsrUFdo9XL6wGIHmwH+', N'Skava', 0, N'vehLyRH08PhhzO3SrxpdEw9C8OA3UpHtOc2n7m0ibKCbpk0pfYiWBGdX8QQX7KCyoTirbxxIpgmDhkstzwzGtv7da57lpgz7P9ZkZxYVpdPXm3OnSXQLbFI44eOZ85It')
INSERT [dbo].[Users] ([Id], [Login], [Password], [Nickname], [Balance], [Salt]) VALUES (9, N'WarMaster', N'e/GqqFJFRYECO9texpssIrJsNyYL0fh1MCuKFb1L8l1nJ5Ow5mzso3M/3jl2AhBUoe2p8/o/VTy0RJc4ALCpMhPp2SdRpb0dYXxI1q4/y2CG/G/M2IoiWQawVNtOHeRv', N'WarMaster', 0, N'08O8vol5MgC7621tSDC0IF94RfejM+AUO8R2Af3+WtYWA6oY/4w177KgkbB0K8PzeFO7g8MNp/yq44vBFsUobobf1wWA8tNPb+FsYfEv7DJoEAugDqo+73WsX/txjuHv')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[Libriary] ([UserId], [GameId]) VALUES (6, 8)
INSERT [dbo].[Libriary] ([UserId], [GameId]) VALUES (6, 9)
INSERT [dbo].[Libriary] ([UserId], [GameId]) VALUES (7, 11)
INSERT [dbo].[Libriary] ([UserId], [GameId]) VALUES (6, 13)
INSERT [dbo].[Libriary] ([UserId], [GameId]) VALUES (6, 18)
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (5, N'dab2c4dd460642308a06544b35edb0c6', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (6, N'dbfc74674bb5443186bfa51a442e984e', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (14, N'3b332467d9e74e93a7a5800885a93181', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (15, N'12a46ee2ab3046c79b082754db3e859e', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (16, N'01ccebe72368491bb47abd5ec4843650', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (17, N'6854aaec3fb54e458d5939e74fc9776d', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (18, N'6665d7914dea4b2991114a9058353832', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (19, N'aaedcb23767a46da978fe9eaf57b4175', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (20, N'12cc9c8266fb483ba5587a2cb838a3be', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (21, N'e855a333fd4d42a6a4e7ea615a92723b', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (22, N'88bfa28c07264a43a3f08c3253d3070d', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (23, N'blank                           ', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (24, N'84b489d6e5b841119528ca554d929c0d', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (25, N'59393fb93ea2464eb6e9e8d44b671d9a', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (26, N'c533f207f73448f89154626764f156f6', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (27, N'2e33cd182298491e86aefa09cc676318', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (28, N'423a93281e764ab6a61751150c261fcc', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (29, N'c7ba301cae0748fc9769ae7d0e8b687e', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (30, N'b3e341e551d0494494a76f4f5ce4d52f', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (31, N'b1eaae6c6dc44f35bc1028c2be98a9f4', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (32, N'c4e4d745c53840649bdd505ab576ca8b', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (33, N'4f9ff3c0334c41ca835db6532fdf3999', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (34, N'3288d2e302ba4cf5914653f623a816eb', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (35, N'70461dc5263b4d1ab088b814e5fba7f3', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (36, N'719bfbe7afb348f6975fb5be62559e12', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (37, N'44bed5535143455ebfe5b7afc758e373', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (38, N'9ec6c99ee8ce4574bb5cf70df388b470', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (39, N'59050c20da144d4b9cc6663d4dc22dbc', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (40, N'ac2f036f54984e8fa569fc88be667f76', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (41, N'b60c1db0e22c4b6f906f0d875197ce34', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (42, N'a0639f2edff44f17aa495529b40aceec', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (43, N'cfc79e98bcc7414497609f0d8e081fd6', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (44, N'f4de96ac49924feaa08eaa1fad8bb16c', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (45, N'ae3003aca1e449e3a372d24f325c1220', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (46, N'52bc19891c574b74b0f02dd7d90aee27', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (47, N'2069ad3bb43d4ddbac1beee56e7563b4', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (48, N'5c9edae78d924127ba1895f953001f6d', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (49, N'9fe45f792a404ee7a37e5a95dc296a5e', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (50, N'5d3179e88cee4cbb84d1c93c6df6e8a0', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (51, N'0f3e0549b3224c6c8ddd61df3bfb6611', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (52, N'7c54d02e580d4261a6206e694f2a599d', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (53, N'cf85f210f8bd440c91448011088dd99f', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (54, N'1866fd2a657f4b8f97e227ccd8b41797', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (55, N'67e35c5201834e7da5cb1dd426e9e3c5', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (56, N'e313c53805df44c997a16afd7d28d028', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (57, N'aa35dd04ae4c48918dd01d120e421f59', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (58, N'3e9a1e6444d640db9211e48e6d3b07d9', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (59, N'8c83a43d426d4c08a10ff1f6974e33d4', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (60, N'd34a36750c7e49929890cafe15d1b969', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (61, N'43d8c773151043299703ad569a986abc', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (62, N'82f618a42c874327a1cbb5a274ca7b29', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (63, N'1d0e054735a44bb8884f911d7f466456', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (64, N'ddbbfa4d15cc4de6b9b0a1425a910d35', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (65, N'ad9d27a67ceb46ac85efc229aa42fae8', N'.jpg')
INSERT [dbo].[Image] ([Id], [Name], [Extension]) VALUES (66, N'fda0b9b2ecfe461cacb37c5ef8229ef3', N'.jpg')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (8, 16)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (8, 17)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (8, 18)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (8, 19)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (9, 20)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (9, 21)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (9, 22)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (10, 27)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (10, 28)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (10, 29)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (11, 30)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (11, 31)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (11, 32)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (11, 33)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (11, 34)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (12, 35)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (12, 36)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (12, 37)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (12, 38)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (13, 39)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (13, 40)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (13, 41)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (14, 42)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (14, 43)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (14, 44)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (15, 45)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (15, 46)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (15, 47)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (16, 48)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (16, 49)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (16, 50)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (17, 51)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (17, 52)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (17, 53)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (18, 54)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (18, 55)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (18, 56)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (18, 57)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (19, 58)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (19, 59)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (19, 60)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (20, 61)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (20, 62)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (20, 63)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (21, 64)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (21, 65)
INSERT [dbo].[Screenshot] ([GameId], [ImageId]) VALUES (21, 66)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'User')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Developer')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Admin')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (4, N'Support')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (5, N'Moderator')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (6, 1)
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (7, 1)
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (8, 1)
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (9, 1)
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (6, 2)
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (7, 4)
INSERT [dbo].[Members] ([UserId], [RoleId]) VALUES (6, 5)
GO
INSERT [dbo].[FriendRequests] ([RequestedById], [RequestedToId], [Status]) VALUES (6, 8, 0)
INSERT [dbo].[FriendRequests] ([RequestedById], [RequestedToId], [Status]) VALUES (7, 6, 1)
INSERT [dbo].[FriendRequests] ([RequestedById], [RequestedToId], [Status]) VALUES (8, 7, 0)
INSERT [dbo].[FriendRequests] ([RequestedById], [RequestedToId], [Status]) VALUES (9, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[SupportCases] ON 

INSERT [dbo].[SupportCases] ([Id], [InitiatorId], [UserId]) VALUES (11, 6, NULL)
SET IDENTITY_INSERT [dbo].[SupportCases] OFF
GO
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (6, 5)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (6, 14)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (6, 15)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (6, 24)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (7, 24)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (8, 24)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (9, 24)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (6, 25)
INSERT [dbo].[Avatar] ([UserId], [ImageId]) VALUES (7, 26)
GO
SET IDENTITY_INSERT [dbo].[SupportMessages] ON 

INSERT [dbo].[SupportMessages] ([Id], [Message], [SupportCaseId], [Time], [MessageType]) VALUES (7, N'hello', 11, CAST(N'2022-02-10T22:14:59.7198226' AS DateTime2), 0)
INSERT [dbo].[SupportMessages] ([Id], [Message], [SupportCaseId], [Time], [MessageType]) VALUES (8, N'sad', 11, CAST(N'2022-02-10T22:15:03.6816043' AS DateTime2), 0)
INSERT [dbo].[SupportMessages] ([Id], [Message], [SupportCaseId], [Time], [MessageType]) VALUES (9, N'hello', 11, CAST(N'2022-02-10T22:15:46.5760054' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[SupportMessages] OFF
GO