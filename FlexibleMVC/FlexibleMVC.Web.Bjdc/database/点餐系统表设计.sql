/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50524
Source Host           : localhost:3306
Source Database       : cnis

Target Server Type    : MYSQL
Target Server Version : 50524
File Encoding         : 65001

Date: 2018-11-25 21:34:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `dc_mealdict`
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealdict`;
CREATE TABLE `dc_mealdict` (
  `ItemID` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '主键、自增列',
  `ItemName` varchar(255) DEFAULT NULL COMMENT 'key',
  `ItemValue` varchar(255) DEFAULT NULL COMMENT 'value',
  `ItemType` varchar(255) DEFAULT NULL COMMENT '字典分类',
  `SortNo` decimal(10,2) DEFAULT NULL COMMENT '排序',
  `IsAllowedEdit` int(4) DEFAULT '1' COMMENT '是否允许编辑：0、不允许，1、允许',
  PRIMARY KEY (`ItemID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=54 DEFAULT CHARSET=utf16 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dc_mealdict
-- ----------------------------
INSERT INTO `dc_mealdict` VALUES ('1', '早餐', '1', '餐别', '1.00', '0');
INSERT INTO `dc_mealdict` VALUES ('2', '中餐', '2', '餐别', '2.00', '0');
INSERT INTO `dc_mealdict` VALUES ('3', '晚餐', '3', '餐别', '3.00', '0');
INSERT INTO `dc_mealdict` VALUES ('14', '周一', '1', '菜单计划', '1.00', '0');
INSERT INTO `dc_mealdict` VALUES ('15', '周二', '2', '菜单计划', '2.00', '0');
INSERT INTO `dc_mealdict` VALUES ('16', '周三', '3', '菜单计划', '3.00', '0');
INSERT INTO `dc_mealdict` VALUES ('17', '周四', '4', '菜单计划', '4.00', '0');
INSERT INTO `dc_mealdict` VALUES ('18', '周五', '5', '菜单计划', '5.00', '0');
INSERT INTO `dc_mealdict` VALUES ('19', '周六', '6', '菜单计划', '6.00', '0');
INSERT INTO `dc_mealdict` VALUES ('20', '周日', '7', '菜单计划', '7.00', '0');
INSERT INTO `dc_mealdict` VALUES ('51', '普食', null, '菜品分类', '3.00', '1');
INSERT INTO `dc_mealdict` VALUES ('52', '半流食', null, '菜品分类', '2.00', '1');
INSERT INTO `dc_mealdict` VALUES ('53', '流食', null, '菜品分类', '1.00', '1');

-- ----------------------------
-- Table structure for `dc_mealmenu`
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealmenu`;
CREATE TABLE `dc_mealmenu` (
  `MealMenuID` bigint(20) NOT NULL AUTO_INCREMENT,
  `SaleName` varchar(255) DEFAULT NULL COMMENT '菜品名称',
  `SalePrice` decimal(10,2) DEFAULT NULL COMMENT '价格',
  `SortNo` decimal(10,2) DEFAULT NULL COMMENT '排序',
  `CategoryID` bigint(20) DEFAULT NULL COMMENT '外键，菜品分类，对应mealdict表ItemID字段',
  `CreateTime` datetime DEFAULT NULL COMMENT '创建时间 yyyy-MM-dd HH:mm:ss',
  `CreateBy` varchar(50) DEFAULT NULL COMMENT '创建人',
  `UpdateTime` datetime DEFAULT NULL COMMENT '修改时间 yyyy-MM-dd HH:mm:ss',
  `UpdateBy` varchar(50) DEFAULT NULL COMMENT '修改人',
  PRIMARY KEY (`MealMenuID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=119 DEFAULT CHARSET=utf16 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dc_mealmenu
-- ----------------------------
INSERT INTO `dc_mealmenu` VALUES ('42', '米汤', '3.00', '1.00', '53', '2018-11-25 20:47:39', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('43', '藕粉', '5.00', '2.00', '53', '2018-11-25 20:47:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('44', '豆腐脑', '3.00', '4.00', '53', '2018-11-25 20:48:25', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('45', '鸡蛋羹', '5.00', '3.00', '53', '2018-11-25 20:48:25', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('46', '南瓜汁', '15.00', '7.00', '53', '2018-11-25 20:49:07', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('47', '南瓜米糊', '8.00', '6.00', '53', '2018-11-25 20:49:07', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('48', '鸡蛋米糊', '10.00', '5.00', '53', '2018-11-25 20:49:07', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('49', '馄饨', '5.00', '4.00', '52', '2018-11-25 20:50:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('50', '虾仁鸡蛋羹', '10.00', '5.00', '52', '2018-11-25 20:50:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('51', '番茄鸡蛋羹', '8.00', '4.50', '52', '2018-11-25 20:50:51', '超级管理员', '2018-11-25 20:59:09', '超级管理员');
INSERT INTO `dc_mealmenu` VALUES ('52', '燕麦粥', '3.00', '3.00', '52', '2018-11-25 20:50:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('53', '小米粥', '3.00', '2.00', '52', '2018-11-25 20:50:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('54', '大米粥', '3.00', '1.00', '52', '2018-11-25 20:50:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('55', '菠菜西蓝花汁', '15.00', '9.00', '52', '2018-11-25 20:51:56', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('56', '蒸南瓜', '8.00', '8.00', '52', '2018-11-25 20:51:56', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('57', '豆浆', '3.00', '7.00', '52', '2018-11-25 20:51:56', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('58', '牛奶', '5.00', '6.00', '52', '2018-11-25 20:51:56', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('59', '蒸红薯', '4.00', '6.00', '51', '2018-11-25 20:53:20', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('60', '芝麻火烧', '2.00', '5.00', '51', '2018-11-25 20:53:20', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('61', '馅饼', '3.00', '4.00', '51', '2018-11-25 20:53:20', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('62', '发糕', '2.00', '3.00', '51', '2018-11-25 20:53:20', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('63', '花卷', '1.00', '2.00', '51', '2018-11-25 20:53:20', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('64', '馒头', '1.00', '1.00', '51', '2018-11-25 20:53:20', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('65', '烧饼夹鸡蛋', '3.00', '10.00', '51', '2018-11-25 20:54:16', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('66', '小笼包', '7.00', '9.00', '51', '2018-11-25 20:54:16', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('67', '肉包子', '2.50', '8.00', '51', '2018-11-25 20:54:16', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('68', '蒸玉米', '4.00', '7.00', '51', '2018-11-25 20:54:16', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('69', '咸菜', '1.00', '13.00', '51', '2018-11-25 20:54:52', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('70', '酱豆腐', '1.00', '12.00', '51', '2018-11-25 20:54:52', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('71', '热拌菜', '10.00', '11.00', '51', '2018-11-25 20:54:52', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('72', '米糊', '10.00', '3.50', '53', '2018-11-25 20:55:48', '超级管理员', '2018-11-25 20:59:22', '超级管理员');
INSERT INTO `dc_mealmenu` VALUES ('73', '菠菜西兰花汁', '15.00', '8.00', '53', '2018-11-25 20:56:30', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('74', '胡萝卜南瓜汁', '15.00', '9.00', '53', '2018-11-25 20:56:46', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('75', '蔬菜粥', '5.00', '10.00', '52', '2018-11-25 20:57:24', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('76', '鸡茸南瓜粥', '15.00', '11.00', '52', '2018-11-25 20:58:19', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('77', '疙瘩汤', '6.00', '12.00', '52', '2018-11-25 20:59:44', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('78', '鸡蛋面片', '12.00', '13.00', '52', '2018-11-25 20:59:56', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('79', '鸡蛋龙须面', '12.00', '14.00', '52', '2018-11-25 21:00:12', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('80', '肉丝莴笋丝', '16.00', '15.00', '52', '2018-11-25 21:00:36', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('81', '红烧豆腐', '12.00', '16.00', '52', '2018-11-25 21:00:55', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('82', '素炒碎油麦菜', '12.00', '17.00', '52', '2018-11-25 21:01:11', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('83', ' 蒸南瓜', '10.00', '18.00', '52', '2018-11-25 21:01:30', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('84', '杂面馒头', '1.50', '16.00', '51', '2018-11-25 21:02:25', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('85', '杂粮饭', '2.00', '15.00', '51', '2018-11-25 21:02:25', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('86', '米饭', '2.00', '14.00', '51', '2018-11-25 21:02:25', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('87', '三丝面', '15.00', '20.00', '51', '2018-11-25 21:03:44', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('88', '烙饼', '1.50', '19.00', '51', '2018-11-25 21:03:44', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('89', '火烧', '2.00', '18.00', '51', '2018-11-25 21:03:44', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('90', '窝头', '2.00', '17.00', '51', '2018-11-25 21:03:44', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('91', '西红柿炒鸡蛋', '16.00', '29.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('92', '苦瓜炒鸡蛋', '16.00', '28.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('93', '锅塌豆腐', '18.00', '27.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('94', '肉末豆腐', '14.00', '26.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('95', '山药炖排骨', '22.00', '25.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('96', '宫爆鸡丁', '18.00', '24.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('97', '肉片焖扁豆', '16.00', '23.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('98', '鲜蘑番茄肉片', '18.00', '22.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('99', '红烧带鱼', '20.00', '21.00', '51', '2018-11-25 21:06:33', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('100', '手撕包菜', '16.00', '37.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('101', '烧茄', '16.00', '36.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('102', '炒杂蔬', '12.00', '35.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('103', '蒜蓉豇豆', '14.00', '34.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('104', '尖椒土豆丝', '14.00', '33.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('105', '胡萝卜鸡腿菇', '16.00', '32.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('106', '素炒三丝', '12.00', '31.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('107', '豉汁油麦菜', '14.00', '30.00', '51', '2018-11-25 21:08:17', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('108', '酸奶', '3.00', '10.00', '53', '2018-11-25 21:08:43', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('109', '肉菜粥', '5.00', '19.00', '52', '2018-11-25 21:09:43', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('110', '肉泥丸子茄丁面片', '12.00', '20.00', '52', '2018-11-25 21:10:07', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('111', '蛋花青菜龙须面', '12.00', '21.00', '52', '2018-11-25 21:10:27', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('112', '滑蛋黄瓜', '16.00', '22.00', '52', '2018-11-25 21:10:51', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('113', '肉末豆花', '12.00', '23.00', '52', '2018-11-25 21:11:11', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('114', '炒碎圆白菜', '16.00', '24.00', '52', '2018-11-25 21:11:34', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('115', '水煮西葫芦', '8.00', '25.00', '52', '2018-11-25 21:11:56', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('116', '西红柿鸡蛋打卤面', '15.00', '31.00', '51', '2018-11-25 21:13:05', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('117', '素炒圆白菜', '14.00', '32.00', '51', '2018-11-25 21:14:13', '超级管理员', '0001-01-01 00:00:00', null);
INSERT INTO `dc_mealmenu` VALUES ('118', '田园小炒', '16.00', '38.00', '51', '2018-11-25 21:15:03', '超级管理员', '0001-01-01 00:00:00', null);

-- ----------------------------
-- Table structure for `dc_mealorder`
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealorder`;
CREATE TABLE `dc_mealorder` (
  `OrderID` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrderTime` datetime DEFAULT NULL COMMENT '订单创建时间 yyyy-MM-dd HH:mm:ss',
  `ContactName` varchar(50) DEFAULT NULL COMMENT '联系人姓名',
  `ContactMobile` varchar(50) DEFAULT NULL COMMENT '联系人手机',
  `DepartmentName` varchar(100) DEFAULT NULL COMMENT '科室名称',
  `BedCode` varchar(50) DEFAULT NULL COMMENT '床号',
  `IsAlreadyPaid` int(4) DEFAULT '0' COMMENT '是否已经支付 0、未支付，1、已支付',
  `PayTime` datetime DEFAULT NULL COMMENT '支付时间 yyyy-MM-dd HH:mm:ss',
  `PayNo` varchar(100) DEFAULT NULL COMMENT '交易单号',
  `OrderMoney` decimal(10,2) DEFAULT NULL COMMENT '订单金额',
  PRIMARY KEY (`OrderID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=54 DEFAULT CHARSET=utf16 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dc_mealorder
-- ----------------------------
INSERT INTO `dc_mealorder` VALUES ('1', '2018-11-08 15:04:10', '张某某', '13569568745', '肿瘤内科', '24', '1', '2018-11-08 15:05:36', '13652365236523658', '18.00');
INSERT INTO `dc_mealorder` VALUES ('2', '2018-11-08 15:04:15', '李某某', '13652541236', '放疗科一病区2病房', '12', '1', '2018-11-08 15:05:40', '13652365236653265', '32.00');
INSERT INTO `dc_mealorder` VALUES ('3', '2018-11-14 17:18:57', '王丛量', '12595685745', '放疗科', '13', '0', null, null, '13.00');
INSERT INTO `dc_mealorder` VALUES ('4', '2018-11-08 15:04:15', '乔不起', '13656985692', '放疗科', '14', '1', '2018-11-08 15:05:40', '13652362366236985', '6.50');

-- ----------------------------
-- Table structure for `dc_mealorderdetail`
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealorderdetail`;
CREATE TABLE `dc_mealorderdetail` (
  `OrderDetailID` bigint(20) NOT NULL AUTO_INCREMENT,
  `OrderID` bigint(20) DEFAULT NULL COMMENT '外键，对应mealorder表OrderID字段',
  `SaleName` varchar(255) DEFAULT NULL COMMENT '菜品名称，对应mealmenu表SaleName字段',
  `SalePrice` decimal(10,2) DEFAULT NULL COMMENT '价格，对应mealmenu表SalePrice字段',
  `SaleNum` int(11) DEFAULT NULL COMMENT '数量',
  `SaleMoney` decimal(10,2) DEFAULT NULL COMMENT '金额，=SalePrice*SaleNum',
  `MealDate` datetime DEFAULT NULL COMMENT '就餐（配送）日期，yyyy-MM-dd',
  `MealTimesName` varchar(50) DEFAULT NULL COMMENT '餐别',
  PRIMARY KEY (`OrderDetailID`) USING BTREE
) ENGINE=MyISAM AUTO_INCREMENT=250 DEFAULT CHARSET=utf16 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dc_mealorderdetail
-- ----------------------------
INSERT INTO `dc_mealorderdetail` VALUES ('1', '1', '鱼香肉丝', '18.00', '1', '18.00', '2018-11-08 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES ('2', '2', '馒头', '0.50', '2', '1.00', '2018-11-09 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES ('3', '2', '豆浆', '2.00', '1', '2.00', '2018-11-09 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES ('4', '3', '蘑菇炒肉', '13.00', '1', '13.00', '2018-11-15 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES ('5', '2', '辣炒鸭血', '15.00', '1', '15.00', '2018-11-09 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES ('6', '2', '肉片木耳', '14.00', '1', '14.00', '2018-11-09 00:00:00', '晚餐');
INSERT INTO `dc_mealorderdetail` VALUES ('247', '4', '豆浆', '2.00', '1', '2.00', '2018-11-08 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES ('249', '2', '豆浆', '2.00', '1', '2.00', '2018-11-09 00:00:00', '早餐');
INSERT INTO `dc_mealorderdetail` VALUES ('248', '4', '油条', '1.50', '1', '1.50', '2018-11-08 00:00:00', '中餐');
INSERT INTO `dc_mealorderdetail` VALUES ('246', '4', '小米粥', '1.50', '2', '3.00', '2018-11-08 00:00:00', '早餐');

-- ----------------------------
-- Table structure for `dc_mealschedule`
-- ----------------------------
DROP TABLE IF EXISTS `dc_mealschedule`;
CREATE TABLE `dc_mealschedule` (
  `DayOfWeek` int(4) NOT NULL COMMENT '周几，数字1~7',
  `MealTimesCode` bigint(20) NOT NULL COMMENT '外键，餐别，对应mealdict表ItemValue字段',
  `MealTimesName` varchar(50) DEFAULT NULL,
  `MealMenuID` bigint(20) NOT NULL COMMENT '外键，对应mealmenu表MealMenuID字段',
  PRIMARY KEY (`DayOfWeek`,`MealTimesCode`,`MealMenuID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf16 ROW_FORMAT=COMPACT;

-- ----------------------------
-- Records of dc_mealschedule
-- ----------------------------
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('1', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('1', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('1', '3', '晚餐', '118');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('2', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('2', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('2', '3', '晚餐', '118');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('3', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('3', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('3', '3', '晚餐', '118');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('4', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('4', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('4', '3', '晚餐', '118');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('5', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('5', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('5', '3', '晚餐', '118');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('6', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('6', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('6', '3', '晚餐', '118');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '44');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '46');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '47');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '49');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '50');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '51');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '52');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '55');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '56');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '57');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '58');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '59');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '60');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '61');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '65');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '66');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '67');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '68');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '69');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '70');
INSERT INTO `dc_mealschedule` VALUES ('7', '1', '早餐', '71');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '72');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '76');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '78');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '79');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '80');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '81');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '82');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '83');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '100');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '102');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('7', '2', '中餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '42');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '43');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '45');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '48');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '53');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '54');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '62');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '63');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '64');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '73');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '74');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '75');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '77');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '84');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '85');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '86');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '88');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '89');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '90');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '91');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '92');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '93');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '94');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '95');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '96');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '97');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '98');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '99');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '101');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '103');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '104');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '105');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '106');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '107');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '108');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '109');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '110');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '111');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '112');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '113');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '114');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '115');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '116');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '117');
INSERT INTO `dc_mealschedule` VALUES ('7', '3', '晚餐', '118');
