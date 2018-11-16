/*
 Navicat MySQL Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50553
 Source Host           : 127.0.0.1:3306
 Source Schema         : cnis_xz

 Target Server Type    : MySQL
 Target Server Version : 50553
 File Encoding         : 65001

 Date: 16/11/2018 10:43:04
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for dc_mealdict
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealdict`;
CREATE TABLE `dc_mealdict`  (
  `ItemID` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键、自增列',
  `ItemName` varchar(255) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT 'key',
  `ItemValue` varchar(255) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT 'value',
  `ItemType` varchar(255) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '字典分类',
  `SortNo` decimal(10, 2) NULL DEFAULT NULL COMMENT '排序',
  `IsAllowedEdit` int(4) NULL DEFAULT 1 COMMENT '是否允许编辑：0、不允许，1、允许',
  PRIMARY KEY (`ItemID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 49 CHARACTER SET = utf16 COLLATE = utf16_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dc_mealdict
-- ----------------------------
INSERT INTO `dc_mealdict` VALUES (1, '早餐', '1', '餐别', 1.00, 0);
INSERT INTO `dc_mealdict` VALUES (2, '中餐', '2', '餐别', 2.00, 0);
INSERT INTO `dc_mealdict` VALUES (3, '晚餐', '3', '餐别', 3.00, 0);
INSERT INTO `dc_mealdict` VALUES (4, '热菜', NULL, '菜品分类', 1.00, 1);
INSERT INTO `dc_mealdict` VALUES (5, '凉菜', NULL, '菜品分类', 2.00, 1);
INSERT INTO `dc_mealdict` VALUES (6, '主食', NULL, '菜品分类', 3.00, 1);
INSERT INTO `dc_mealdict` VALUES (7, '汤类', NULL, '菜品分类', 2.30, 1);
INSERT INTO `dc_mealdict` VALUES (8, '粥类', NULL, '菜品分类', 5.00, 1);
INSERT INTO `dc_mealdict` VALUES (9, '甜品', NULL, '菜品分类', 6.00, 1);
INSERT INTO `dc_mealdict` VALUES (10, '豆制品', NULL, '菜品分类', 7.00, 1);
INSERT INTO `dc_mealdict` VALUES (11, '煲类', NULL, '菜品分类', 8.00, 1);
INSERT INTO `dc_mealdict` VALUES (14, '周一', '1', '菜单计划', 1.00, 0);
INSERT INTO `dc_mealdict` VALUES (15, '周二', '2', '菜单计划', 2.00, 0);
INSERT INTO `dc_mealdict` VALUES (16, '周三', '3', '菜单计划', 3.00, 0);
INSERT INTO `dc_mealdict` VALUES (17, '周四', '4', '菜单计划', 4.00, 0);
INSERT INTO `dc_mealdict` VALUES (18, '周五', '5', '菜单计划', 5.00, 0);
INSERT INTO `dc_mealdict` VALUES (19, '周六', '6', '菜单计划', 6.00, 0);
INSERT INTO `dc_mealdict` VALUES (20, '周日', '7', '菜单计划', 7.00, 0);

-- ----------------------------
-- Table structure for dc_mealmenu
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealmenu`;
CREATE TABLE `dc_mealmenu`  (
  `MealMenuID` bigint(20) NOT NULL AUTO_INCREMENT,
  `SaleName` varchar(255) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '菜品名称',
  `SalePrice` decimal(10, 2) NULL DEFAULT NULL COMMENT '价格',
  `SortNo` decimal(10, 0) NULL DEFAULT NULL COMMENT '排序',
  `CategoryID` bigint(20) NULL DEFAULT NULL COMMENT '外键，菜品分类，对应mealdict表ItemID字段',
  `CreateTime` datetime NULL DEFAULT NULL COMMENT '创建时间 yyyy-MM-dd HH:mm:ss',
  `CreateBy` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime NULL DEFAULT NULL COMMENT '修改时间 yyyy-MM-dd HH:mm:ss',
  `UpdateBy` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`MealMenuID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 40 CHARACTER SET = utf16 COLLATE = utf16_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dc_mealmenu
-- ----------------------------
INSERT INTO `dc_mealmenu` VALUES (1, '鱼香肉丝', 19.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-13 14:51:05', '');
INSERT INTO `dc_mealmenu` VALUES (2, '馒头', 0.50, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (3, '花卷', 1.00, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (4, '麻婆豆腐', 12.00, 9, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-13 14:51:11', '');
INSERT INTO `dc_mealmenu` VALUES (5, '西红柿炒鸡蛋', 12.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (6, '辣子鸡块', 13.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (7, '蘑菇炒肉', 13.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (8, '豆苗肉丝', 14.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (9, '辣炒鸭血', 15.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (10, '醋溜山药', 16.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (11, '肉片木耳', 14.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (12, '糖醋里脊', 20.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (13, '酸辣土豆丝', 12.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (14, '海鲜菇炒肉', 15.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (15, '尖椒大葱炒鸡蛋', 14.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (16, '小米粥', 1.50, 1, 8, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (17, '豆浆', 2.00, 1, 10, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (18, '油条', 1.50, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (19, '香菇包', 0.80, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (20, '豆角包', 0.80, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (21, '猪肉包', 1.50, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (22, '菠菜拌银耳', 16.00, 1, 5, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (23, '拍黄瓜', 10.00, 1, 5, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (24, '凉拌腐皮', 10.00, 1, 5, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (25, '盐水花生', 8.00, 1, 5, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (26, '辣炒千页豆腐', 9.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (27, '鸭血豆腐', 16.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (28, '炒面', 12.00, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (29, '辣子肉片', 18.00, 1, 4, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (30, '米饭', 1.00, 1, 6, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (31, '鸡公煲', 30.00, 1, 11, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (32, '鸡蛋汤', 5.00, 1, 7, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');
INSERT INTO `dc_mealmenu` VALUES (33, '奶油点心', 1.00, 1, 9, '2018-11-08 11:14:30', '系统管理员', '2018-11-08 11:14:30', '系统管理员');

-- ----------------------------
-- Table structure for dc_mealorder
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealorder`;
CREATE TABLE `dc_mealorder`  (
  `OrderID` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrderTime` datetime NULL DEFAULT NULL COMMENT '订单创建时间 yyyy-MM-dd HH:mm:ss',
  `ContactName` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '联系人姓名',
  `ContactMobile` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '联系人手机',
  `DepartmentName` varchar(100) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '科室名称',
  `BedCode` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '床号',
  `IsAlreadyPaid` int(4) NULL DEFAULT 0 COMMENT '是否已经支付 0、未支付，1、已支付',
  `PayTime` datetime NULL DEFAULT NULL COMMENT '支付时间 yyyy-MM-dd HH:mm:ss',
  `PayNo` varchar(100) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '交易单号',
  `OrderMoney` decimal(10, 2) NULL DEFAULT NULL COMMENT '订单金额',
  PRIMARY KEY (`OrderID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 54 CHARACTER SET = utf16 COLLATE = utf16_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dc_mealorder
-- ----------------------------
INSERT INTO `dc_mealorder` VALUES (1, '2018-11-08 15:04:10', '张某某', '13569568745', '肿瘤内科', '24', 1, '2018-11-08 15:05:36', '13652365236523658', 18.00);
INSERT INTO `dc_mealorder` VALUES (2, '2018-11-08 15:04:15', '李某某', '13652541236', '放疗科一病区2病房', '12', 1, '2018-11-08 15:05:40', '13652365236653265', 32.00);
INSERT INTO `dc_mealorder` VALUES (3, '2018-11-14 17:18:57', '王丛量', '12595685745', '放疗科', '13', 0, NULL, NULL, 13.00);
INSERT INTO `dc_mealorder` VALUES (4, '2018-11-08 15:04:15', '乔不起', '13656985692', '放疗科', '14', 1, '2018-11-08 15:05:40', '13652362366236985', 6.50);

-- ----------------------------
-- Table structure for dc_mealorderdetail
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealorderdetail`;
CREATE TABLE `dc_mealorderdetail`  (
  `OrderDetailID` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrderID` bigint(20) NULL DEFAULT NULL COMMENT '外键，对应mealorder表OrderID字段',
  `SaleName` varchar(255) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '菜品名称，对应mealmenu表SaleName字段',
  `SalePrice` decimal(10, 2) NULL DEFAULT NULL COMMENT '价格，对应mealmenu表SalePrice字段',
  `SaleNum` int(11) NULL DEFAULT NULL COMMENT '数量',
  `SaleMoney` decimal(10, 2) NULL DEFAULT NULL COMMENT '金额，=SalePrice*SaleNum',
  `MealDate` datetime NULL DEFAULT NULL COMMENT '就餐（配送）日期，yyyy-MM-dd',
  `MealTimesName` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL COMMENT '餐别',
  PRIMARY KEY (`OrderDetailID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 250 CHARACTER SET = utf16 COLLATE = utf16_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dc_mealorderdetail
-- ----------------------------
INSERT INTO `dc_mealorderdetail` VALUES (1, 1, '鱼香肉丝', 18.00, 1, 18.00, '2018-11-08 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES (2, 2, '馒头', 0.50, 2, 1.00, '2018-11-09 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES (3, 2, '豆浆', 2.00, 1, 2.00, '2018-11-09 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES (4, 3, '蘑菇炒肉', 13.00, 1, 13.00, '2018-11-15 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES (5, 2, '辣炒鸭血', 15.00, 1, 15.00, '2018-11-09 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES (6, 2, '肉片木耳', 14.00, 1, 14.00, '2018-11-09 00:00:00', '晚餐');
INSERT INTO `dc_mealorderdetail` VALUES (247, 4, '豆浆', 2.00, 1, 2.00, '2018-11-08 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES (249, 2, '豆浆', 2.00, 1, 2.00, '2018-11-09 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES (248, 4, '油条', 1.50, 1, 1.50, '2018-11-08 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES (246, 4, '小米粥', 1.50, 2, 3.00, '2018-11-08 00:00:00', '早餐');

-- ----------------------------
-- Table structure for dc_mealschedule
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealschedule`;
CREATE TABLE `dc_mealschedule`  (
  `DayOfWeek` int(4) NOT NULL COMMENT '周几，数字1~7',
  `MealTimesCode` bigint(20) NOT NULL COMMENT '外键，餐别，对应mealdict表ItemValue字段',
  `MealTimesName` varchar(50) CHARACTER SET utf16 COLLATE utf16_general_ci NULL DEFAULT NULL,
  `MealMenuID` bigint(20) NOT NULL COMMENT '外键，对应mealmenu表MealMenuID字段',
  PRIMARY KEY (`DayOfWeek`, `MealTimesCode`, `MealMenuID`) USING BTREE
) ENGINE = MyISAM CHARACTER SET = utf16 COLLATE = utf16_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dc_mealschedule
-- ----------------------------
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 18);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 12);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 14);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 8);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (1, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 7);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 6);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 5);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 1);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 18);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 3);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 2);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 7);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 19);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 6);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (2, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (2, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (2, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (2, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (2, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 29);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 2);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 3);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 4);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 13);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 6);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (3, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (3, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (3, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (3, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (6, 1, '早餐', 17);
INSERT INTO `dc_mealschedule` VALUES (5, 1, '早餐', 17);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 8);
INSERT INTO `dc_mealschedule` VALUES (4, 1, '早餐', 4);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 6);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (4, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (4, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (4, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (4, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (4, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (5, 1, '早餐', 18);
INSERT INTO `dc_mealschedule` VALUES (5, 1, '早餐', 3);
INSERT INTO `dc_mealschedule` VALUES (5, 1, '早餐', 2);
INSERT INTO `dc_mealschedule` VALUES (5, 1, '早餐', 32);
INSERT INTO `dc_mealschedule` VALUES (5, 1, '早餐', 4);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 6);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (5, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (5, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (5, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (5, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (5, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (6, 1, '早餐', 18);
INSERT INTO `dc_mealschedule` VALUES (6, 1, '早餐', 3);
INSERT INTO `dc_mealschedule` VALUES (6, 1, '早餐', 2);
INSERT INTO `dc_mealschedule` VALUES (6, 1, '早餐', 32);
INSERT INTO `dc_mealschedule` VALUES (6, 1, '早餐', 4);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 6);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (6, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (6, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (6, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (6, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (6, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (7, 1, '早餐', 2);
INSERT INTO `dc_mealschedule` VALUES (7, 1, '早餐', 3);
INSERT INTO `dc_mealschedule` VALUES (7, 1, '早餐', 17);
INSERT INTO `dc_mealschedule` VALUES (7, 1, '早餐', 18);
INSERT INTO `dc_mealschedule` VALUES (7, 1, '早餐', 32);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 4);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 5);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 6);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 7);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 8);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 9);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 10);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 11);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 28);
INSERT INTO `dc_mealschedule` VALUES (7, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (7, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (7, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (7, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (7, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 9);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 12);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 13);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 14);
INSERT INTO `dc_mealschedule` VALUES (1, 3, '晚餐', 15);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 19);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 20);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 21);
INSERT INTO `dc_mealschedule` VALUES (3, 1, '早餐', 28);
INSERT INTO `dc_mealschedule` VALUES (2, 3, '晚餐', 23);
INSERT INTO `dc_mealschedule` VALUES (2, 3, '晚餐', 24);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 26);
INSERT INTO `dc_mealschedule` VALUES (3, 2, '中餐', 30);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 10);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 21);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 20);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 3);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 2);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 4);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 8);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 7);
INSERT INTO `dc_mealschedule` VALUES (1, 1, '早餐', 19);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 28);
INSERT INTO `dc_mealschedule` VALUES (2, 1, '早餐', 30);

SET FOREIGN_KEY_CHECKS = 1;
