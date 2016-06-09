//
//  _MDPLocaleDescriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLocaleDescriptionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLocaleDescriptionModelAttributes {
	__unsafe_unretained NSString *descriptionLocaleDescription;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *locale;
} MDPLocaleDescriptionModelAttributes;

extern const struct MDPLocaleDescriptionModelRelationships {
	__unsafe_unretained NSString *achievementConfigurationDescriptionAchievementConfiguration;
	__unsafe_unretained NSString *achievementConfigurationLevelName;
	__unsafe_unretained NSString *achievementConfigurationTypeName;
	__unsafe_unretained NSString *achievementDescriptionAchievement;
	__unsafe_unretained NSString *achievementLevelName;
	__unsafe_unretained NSString *bodyPlatformNotificationText;
	__unsafe_unretained NSString *checkInTypeContents;
	__unsafe_unretained NSString *checkInTypeDescriptionCheckInType;
	__unsafe_unretained NSString *competition;
	__unsafe_unretained NSString *fanOfferBody;
	__unsafe_unretained NSString *fanOfferImageUrl;
	__unsafe_unretained NSString *fanOfferTitle;
	__unsafe_unretained NSString *fanVirtualGoodDescriptionFanVirtualGood;
	__unsafe_unretained NSString *fanVirtualGoodUrl;
	__unsafe_unretained NSString *gamificationLevelName;
	__unsafe_unretained NSString *groupDescriptionGroup;
	__unsafe_unretained NSString *groupThreadDescriptionGroupThread;
	__unsafe_unretained NSString *languageDescriptionLanguage;
	__unsafe_unretained NSString *matchDescriptionMatch;
	__unsafe_unretained NSString *menuFrameUrl;
	__unsafe_unretained NSString *menuText;
	__unsafe_unretained NSString *playerTwitterAccounts;
	__unsafe_unretained NSString *pointsTransactionActionDescription;
	__unsafe_unretained NSString *storeProductDescriptionStoreProduct;
	__unsafe_unretained NSString *storeProductTitle;
	__unsafe_unretained NSString *subscriptionConfigurationBasicInfoDescriptionSubscriptionConfigurationBasicInfo;
	__unsafe_unretained NSString *subscriptionConfigurationBasicInfoImage;
	__unsafe_unretained NSString *subscriptionConfigurationBasicInfoThumbnailImage;
	__unsafe_unretained NSString *subscriptionConfigurationBasicInfoTitle;
	__unsafe_unretained NSString *subscriptionConfigurationDescriptionSubscriptionConfiguration;
	__unsafe_unretained NSString *subscriptionConfigurationImage;
	__unsafe_unretained NSString *subscriptionConfigurationThumbnailImage;
	__unsafe_unretained NSString *subscriptionConfigurationTitle;
	__unsafe_unretained NSString *subscriptionConfigurationTypeName;
	__unsafe_unretained NSString *tanInfoName;
	__unsafe_unretained NSString *virtualGoodResultsVirtualGood;
	__unsafe_unretained NSString *virtualGoodTypeDescriptionVirtualGoodType;
	__unsafe_unretained NSString *virtualGoodUrl;
} MDPLocaleDescriptionModelRelationships;

@class MDPAchievementConfigurationModel;
@class MDPAchievementConfigurationModel;
@class MDPAchievementConfigurationTypeModel;
@class MDPAchievementModel;
@class MDPAchievementModel;
@class MDPBodyPlatformNotificationModel;
@class MDPCheckInTypeModel;
@class MDPCheckInTypeModel;
@class MDPCompetitionModel;
@class MDPFanOfferModel;
@class MDPFanOfferModel;
@class MDPFanOfferModel;
@class MDPFanVirtualGoodModel;
@class MDPFanVirtualGoodModel;
@class MDPGamificationLevelBasicInfoModel;
@class MDPGroupModel;
@class MDPGroupThreadModel;
@class MDPLanguageModel;
@class MDPMatchModel;
@class MDPMenuModel;
@class MDPMenuModel;
@class MDPPlayerModel;
@class MDPPointsTransactionModel;
@class MDPStoreProductModel;
@class MDPStoreProductModel;
@class MDPSubscriptionConfigurationBasicInfoModel;
@class MDPSubscriptionConfigurationBasicInfoModel;
@class MDPSubscriptionConfigurationBasicInfoModel;
@class MDPSubscriptionConfigurationBasicInfoModel;
@class MDPSubscriptionConfigurationModel;
@class MDPSubscriptionConfigurationModel;
@class MDPSubscriptionConfigurationModel;
@class MDPSubscriptionConfigurationModel;
@class MDPSubscriptionConfigurationTypeModel;
@class MDPTagInfoModel;
@class MDPVirtualGoodModel;
@class MDPVirtualGoodTypeModel;
@class MDPVirtualGoodModel;

@interface _MDPLocaleDescriptionModel : NSManagedObject

@property (nonatomic, strong) NSString* descriptionLocaleDescription;

//- (BOOL)validateDescriptionLocaleDescription:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* locale;

//- (BOOL)validateLocale:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *achievementConfigurationDescriptionAchievementConfiguration;

- (NSMutableSet*)achievementConfigurationDescriptionAchievementConfigurationSet;

@property (nonatomic, strong) NSSet *achievementConfigurationLevelName;

- (NSMutableSet*)achievementConfigurationLevelNameSet;

@property (nonatomic, strong) NSSet *achievementConfigurationTypeName;

- (NSMutableSet*)achievementConfigurationTypeNameSet;

@property (nonatomic, strong) NSSet *achievementDescriptionAchievement;

- (NSMutableSet*)achievementDescriptionAchievementSet;

@property (nonatomic, strong) NSSet *achievementLevelName;

- (NSMutableSet*)achievementLevelNameSet;

@property (nonatomic, strong) NSSet *bodyPlatformNotificationText;

- (NSMutableSet*)bodyPlatformNotificationTextSet;

@property (nonatomic, strong) NSSet *checkInTypeContents;

- (NSMutableSet*)checkInTypeContentsSet;

@property (nonatomic, strong) NSSet *checkInTypeDescriptionCheckInType;

- (NSMutableSet*)checkInTypeDescriptionCheckInTypeSet;

@property (nonatomic, strong) NSSet *competition;

- (NSMutableSet*)competitionSet;

@property (nonatomic, strong) MDPFanOfferModel *fanOfferBody;

//- (BOOL)validateFanOfferBody:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFanOfferModel *fanOfferImageUrl;

//- (BOOL)validateFanOfferImageUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFanOfferModel *fanOfferTitle;

//- (BOOL)validateFanOfferTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *fanVirtualGoodDescriptionFanVirtualGood;

- (NSMutableSet*)fanVirtualGoodDescriptionFanVirtualGoodSet;

@property (nonatomic, strong) NSSet *fanVirtualGoodUrl;

- (NSMutableSet*)fanVirtualGoodUrlSet;

@property (nonatomic, strong) MDPGamificationLevelBasicInfoModel *gamificationLevelName;

//- (BOOL)validateGamificationLevelName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPGroupModel *groupDescriptionGroup;

//- (BOOL)validateGroupDescriptionGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPGroupThreadModel *groupThreadDescriptionGroupThread;

//- (BOOL)validateGroupThreadDescriptionGroupThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *languageDescriptionLanguage;

- (NSMutableSet*)languageDescriptionLanguageSet;

@property (nonatomic, strong) MDPMatchModel *matchDescriptionMatch;

//- (BOOL)validateMatchDescriptionMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *menuFrameUrl;

- (NSMutableSet*)menuFrameUrlSet;

@property (nonatomic, strong) NSSet *menuText;

- (NSMutableSet*)menuTextSet;

@property (nonatomic, strong) MDPPlayerModel *playerTwitterAccounts;

//- (BOOL)validatePlayerTwitterAccounts:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *pointsTransactionActionDescription;

- (NSMutableSet*)pointsTransactionActionDescriptionSet;

@property (nonatomic, strong) NSSet *storeProductDescriptionStoreProduct;

- (NSMutableSet*)storeProductDescriptionStoreProductSet;

@property (nonatomic, strong) MDPStoreProductModel *storeProductTitle;

//- (BOOL)validateStoreProductTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationBasicInfoModel *subscriptionConfigurationBasicInfoDescriptionSubscriptionConfigurationBasicInfo;

//- (BOOL)validateSubscriptionConfigurationBasicInfoDescriptionSubscriptionConfigurationBasicInfo:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *subscriptionConfigurationBasicInfoImage;

- (NSMutableSet*)subscriptionConfigurationBasicInfoImageSet;

@property (nonatomic, strong) MDPSubscriptionConfigurationBasicInfoModel *subscriptionConfigurationBasicInfoThumbnailImage;

//- (BOOL)validateSubscriptionConfigurationBasicInfoThumbnailImage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationBasicInfoModel *subscriptionConfigurationBasicInfoTitle;

//- (BOOL)validateSubscriptionConfigurationBasicInfoTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationModel *subscriptionConfigurationDescriptionSubscriptionConfiguration;

//- (BOOL)validateSubscriptionConfigurationDescriptionSubscriptionConfiguration:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationModel *subscriptionConfigurationImage;

//- (BOOL)validateSubscriptionConfigurationImage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationModel *subscriptionConfigurationThumbnailImage;

//- (BOOL)validateSubscriptionConfigurationThumbnailImage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationModel *subscriptionConfigurationTitle;

//- (BOOL)validateSubscriptionConfigurationTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPSubscriptionConfigurationTypeModel *subscriptionConfigurationTypeName;

//- (BOOL)validateSubscriptionConfigurationTypeName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *tanInfoName;

- (NSMutableSet*)tanInfoNameSet;

@property (nonatomic, strong) NSSet *virtualGoodResultsVirtualGood;

- (NSMutableSet*)virtualGoodResultsVirtualGoodSet;

@property (nonatomic, strong) NSSet *virtualGoodTypeDescriptionVirtualGoodType;

- (NSMutableSet*)virtualGoodTypeDescriptionVirtualGoodTypeSet;

@property (nonatomic, strong) NSSet *virtualGoodUrl;

- (NSMutableSet*)virtualGoodUrlSet;

@end

@interface _MDPLocaleDescriptionModel (AchievementConfigurationDescriptionAchievementConfigurationCoreDataGeneratedAccessors)
- (void)addAchievementConfigurationDescriptionAchievementConfiguration:(NSSet*)value_;
- (void)removeAchievementConfigurationDescriptionAchievementConfiguration:(NSSet*)value_;
- (void)addAchievementConfigurationDescriptionAchievementConfigurationObject:(MDPAchievementConfigurationModel*)value_;
- (void)removeAchievementConfigurationDescriptionAchievementConfigurationObject:(MDPAchievementConfigurationModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (AchievementConfigurationLevelNameCoreDataGeneratedAccessors)
- (void)addAchievementConfigurationLevelName:(NSSet*)value_;
- (void)removeAchievementConfigurationLevelName:(NSSet*)value_;
- (void)addAchievementConfigurationLevelNameObject:(MDPAchievementConfigurationModel*)value_;
- (void)removeAchievementConfigurationLevelNameObject:(MDPAchievementConfigurationModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (AchievementConfigurationTypeNameCoreDataGeneratedAccessors)
- (void)addAchievementConfigurationTypeName:(NSSet*)value_;
- (void)removeAchievementConfigurationTypeName:(NSSet*)value_;
- (void)addAchievementConfigurationTypeNameObject:(MDPAchievementConfigurationTypeModel*)value_;
- (void)removeAchievementConfigurationTypeNameObject:(MDPAchievementConfigurationTypeModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (AchievementDescriptionAchievementCoreDataGeneratedAccessors)
- (void)addAchievementDescriptionAchievement:(NSSet*)value_;
- (void)removeAchievementDescriptionAchievement:(NSSet*)value_;
- (void)addAchievementDescriptionAchievementObject:(MDPAchievementModel*)value_;
- (void)removeAchievementDescriptionAchievementObject:(MDPAchievementModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (AchievementLevelNameCoreDataGeneratedAccessors)
- (void)addAchievementLevelName:(NSSet*)value_;
- (void)removeAchievementLevelName:(NSSet*)value_;
- (void)addAchievementLevelNameObject:(MDPAchievementModel*)value_;
- (void)removeAchievementLevelNameObject:(MDPAchievementModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (BodyPlatformNotificationTextCoreDataGeneratedAccessors)
- (void)addBodyPlatformNotificationText:(NSSet*)value_;
- (void)removeBodyPlatformNotificationText:(NSSet*)value_;
- (void)addBodyPlatformNotificationTextObject:(MDPBodyPlatformNotificationModel*)value_;
- (void)removeBodyPlatformNotificationTextObject:(MDPBodyPlatformNotificationModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (CheckInTypeContentsCoreDataGeneratedAccessors)
- (void)addCheckInTypeContents:(NSSet*)value_;
- (void)removeCheckInTypeContents:(NSSet*)value_;
- (void)addCheckInTypeContentsObject:(MDPCheckInTypeModel*)value_;
- (void)removeCheckInTypeContentsObject:(MDPCheckInTypeModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (CheckInTypeDescriptionCheckInTypeCoreDataGeneratedAccessors)
- (void)addCheckInTypeDescriptionCheckInType:(NSSet*)value_;
- (void)removeCheckInTypeDescriptionCheckInType:(NSSet*)value_;
- (void)addCheckInTypeDescriptionCheckInTypeObject:(MDPCheckInTypeModel*)value_;
- (void)removeCheckInTypeDescriptionCheckInTypeObject:(MDPCheckInTypeModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (CompetitionCoreDataGeneratedAccessors)
- (void)addCompetition:(NSSet*)value_;
- (void)removeCompetition:(NSSet*)value_;
- (void)addCompetitionObject:(MDPCompetitionModel*)value_;
- (void)removeCompetitionObject:(MDPCompetitionModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (FanVirtualGoodDescriptionFanVirtualGoodCoreDataGeneratedAccessors)
- (void)addFanVirtualGoodDescriptionFanVirtualGood:(NSSet*)value_;
- (void)removeFanVirtualGoodDescriptionFanVirtualGood:(NSSet*)value_;
- (void)addFanVirtualGoodDescriptionFanVirtualGoodObject:(MDPFanVirtualGoodModel*)value_;
- (void)removeFanVirtualGoodDescriptionFanVirtualGoodObject:(MDPFanVirtualGoodModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (FanVirtualGoodUrlCoreDataGeneratedAccessors)
- (void)addFanVirtualGoodUrl:(NSSet*)value_;
- (void)removeFanVirtualGoodUrl:(NSSet*)value_;
- (void)addFanVirtualGoodUrlObject:(MDPFanVirtualGoodModel*)value_;
- (void)removeFanVirtualGoodUrlObject:(MDPFanVirtualGoodModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (LanguageDescriptionLanguageCoreDataGeneratedAccessors)
- (void)addLanguageDescriptionLanguage:(NSSet*)value_;
- (void)removeLanguageDescriptionLanguage:(NSSet*)value_;
- (void)addLanguageDescriptionLanguageObject:(MDPLanguageModel*)value_;
- (void)removeLanguageDescriptionLanguageObject:(MDPLanguageModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (MenuFrameUrlCoreDataGeneratedAccessors)
- (void)addMenuFrameUrl:(NSSet*)value_;
- (void)removeMenuFrameUrl:(NSSet*)value_;
- (void)addMenuFrameUrlObject:(MDPMenuModel*)value_;
- (void)removeMenuFrameUrlObject:(MDPMenuModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (MenuTextCoreDataGeneratedAccessors)
- (void)addMenuText:(NSSet*)value_;
- (void)removeMenuText:(NSSet*)value_;
- (void)addMenuTextObject:(MDPMenuModel*)value_;
- (void)removeMenuTextObject:(MDPMenuModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (PointsTransactionActionDescriptionCoreDataGeneratedAccessors)
- (void)addPointsTransactionActionDescription:(NSSet*)value_;
- (void)removePointsTransactionActionDescription:(NSSet*)value_;
- (void)addPointsTransactionActionDescriptionObject:(MDPPointsTransactionModel*)value_;
- (void)removePointsTransactionActionDescriptionObject:(MDPPointsTransactionModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (StoreProductDescriptionStoreProductCoreDataGeneratedAccessors)
- (void)addStoreProductDescriptionStoreProduct:(NSSet*)value_;
- (void)removeStoreProductDescriptionStoreProduct:(NSSet*)value_;
- (void)addStoreProductDescriptionStoreProductObject:(MDPStoreProductModel*)value_;
- (void)removeStoreProductDescriptionStoreProductObject:(MDPStoreProductModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (SubscriptionConfigurationBasicInfoImageCoreDataGeneratedAccessors)
- (void)addSubscriptionConfigurationBasicInfoImage:(NSSet*)value_;
- (void)removeSubscriptionConfigurationBasicInfoImage:(NSSet*)value_;
- (void)addSubscriptionConfigurationBasicInfoImageObject:(MDPSubscriptionConfigurationBasicInfoModel*)value_;
- (void)removeSubscriptionConfigurationBasicInfoImageObject:(MDPSubscriptionConfigurationBasicInfoModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (TanInfoNameCoreDataGeneratedAccessors)
- (void)addTanInfoName:(NSSet*)value_;
- (void)removeTanInfoName:(NSSet*)value_;
- (void)addTanInfoNameObject:(MDPTagInfoModel*)value_;
- (void)removeTanInfoNameObject:(MDPTagInfoModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (VirtualGoodResultsVirtualGoodCoreDataGeneratedAccessors)
- (void)addVirtualGoodResultsVirtualGood:(NSSet*)value_;
- (void)removeVirtualGoodResultsVirtualGood:(NSSet*)value_;
- (void)addVirtualGoodResultsVirtualGoodObject:(MDPVirtualGoodModel*)value_;
- (void)removeVirtualGoodResultsVirtualGoodObject:(MDPVirtualGoodModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (VirtualGoodTypeDescriptionVirtualGoodTypeCoreDataGeneratedAccessors)
- (void)addVirtualGoodTypeDescriptionVirtualGoodType:(NSSet*)value_;
- (void)removeVirtualGoodTypeDescriptionVirtualGoodType:(NSSet*)value_;
- (void)addVirtualGoodTypeDescriptionVirtualGoodTypeObject:(MDPVirtualGoodTypeModel*)value_;
- (void)removeVirtualGoodTypeDescriptionVirtualGoodTypeObject:(MDPVirtualGoodTypeModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (VirtualGoodUrlCoreDataGeneratedAccessors)
- (void)addVirtualGoodUrl:(NSSet*)value_;
- (void)removeVirtualGoodUrl:(NSSet*)value_;
- (void)addVirtualGoodUrlObject:(MDPVirtualGoodModel*)value_;
- (void)removeVirtualGoodUrlObject:(MDPVirtualGoodModel*)value_;
@end

@interface _MDPLocaleDescriptionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveDescriptionLocaleDescription;
- (void)setPrimitiveDescriptionLocaleDescription:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveLocale;
- (void)setPrimitiveLocale:(NSString*)value;

- (NSMutableSet*)primitiveAchievementConfigurationDescriptionAchievementConfiguration;
- (void)setPrimitiveAchievementConfigurationDescriptionAchievementConfiguration:(NSMutableSet*)value;

- (NSMutableSet*)primitiveAchievementConfigurationLevelName;
- (void)setPrimitiveAchievementConfigurationLevelName:(NSMutableSet*)value;

- (NSMutableSet*)primitiveAchievementConfigurationTypeName;
- (void)setPrimitiveAchievementConfigurationTypeName:(NSMutableSet*)value;

- (NSMutableSet*)primitiveAchievementDescriptionAchievement;
- (void)setPrimitiveAchievementDescriptionAchievement:(NSMutableSet*)value;

- (NSMutableSet*)primitiveAchievementLevelName;
- (void)setPrimitiveAchievementLevelName:(NSMutableSet*)value;

- (NSMutableSet*)primitiveBodyPlatformNotificationText;
- (void)setPrimitiveBodyPlatformNotificationText:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCheckInTypeContents;
- (void)setPrimitiveCheckInTypeContents:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCheckInTypeDescriptionCheckInType;
- (void)setPrimitiveCheckInTypeDescriptionCheckInType:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCompetition;
- (void)setPrimitiveCompetition:(NSMutableSet*)value;

- (MDPFanOfferModel*)primitiveFanOfferBody;
- (void)setPrimitiveFanOfferBody:(MDPFanOfferModel*)value;

- (MDPFanOfferModel*)primitiveFanOfferImageUrl;
- (void)setPrimitiveFanOfferImageUrl:(MDPFanOfferModel*)value;

- (MDPFanOfferModel*)primitiveFanOfferTitle;
- (void)setPrimitiveFanOfferTitle:(MDPFanOfferModel*)value;

- (NSMutableSet*)primitiveFanVirtualGoodDescriptionFanVirtualGood;
- (void)setPrimitiveFanVirtualGoodDescriptionFanVirtualGood:(NSMutableSet*)value;

- (NSMutableSet*)primitiveFanVirtualGoodUrl;
- (void)setPrimitiveFanVirtualGoodUrl:(NSMutableSet*)value;

- (MDPGamificationLevelBasicInfoModel*)primitiveGamificationLevelName;
- (void)setPrimitiveGamificationLevelName:(MDPGamificationLevelBasicInfoModel*)value;

- (MDPGroupModel*)primitiveGroupDescriptionGroup;
- (void)setPrimitiveGroupDescriptionGroup:(MDPGroupModel*)value;

- (MDPGroupThreadModel*)primitiveGroupThreadDescriptionGroupThread;
- (void)setPrimitiveGroupThreadDescriptionGroupThread:(MDPGroupThreadModel*)value;

- (NSMutableSet*)primitiveLanguageDescriptionLanguage;
- (void)setPrimitiveLanguageDescriptionLanguage:(NSMutableSet*)value;

- (MDPMatchModel*)primitiveMatchDescriptionMatch;
- (void)setPrimitiveMatchDescriptionMatch:(MDPMatchModel*)value;

- (NSMutableSet*)primitiveMenuFrameUrl;
- (void)setPrimitiveMenuFrameUrl:(NSMutableSet*)value;

- (NSMutableSet*)primitiveMenuText;
- (void)setPrimitiveMenuText:(NSMutableSet*)value;

- (MDPPlayerModel*)primitivePlayerTwitterAccounts;
- (void)setPrimitivePlayerTwitterAccounts:(MDPPlayerModel*)value;

- (NSMutableSet*)primitivePointsTransactionActionDescription;
- (void)setPrimitivePointsTransactionActionDescription:(NSMutableSet*)value;

- (NSMutableSet*)primitiveStoreProductDescriptionStoreProduct;
- (void)setPrimitiveStoreProductDescriptionStoreProduct:(NSMutableSet*)value;

- (MDPStoreProductModel*)primitiveStoreProductTitle;
- (void)setPrimitiveStoreProductTitle:(MDPStoreProductModel*)value;

- (MDPSubscriptionConfigurationBasicInfoModel*)primitiveSubscriptionConfigurationBasicInfoDescriptionSubscriptionConfigurationBasicInfo;
- (void)setPrimitiveSubscriptionConfigurationBasicInfoDescriptionSubscriptionConfigurationBasicInfo:(MDPSubscriptionConfigurationBasicInfoModel*)value;

- (NSMutableSet*)primitiveSubscriptionConfigurationBasicInfoImage;
- (void)setPrimitiveSubscriptionConfigurationBasicInfoImage:(NSMutableSet*)value;

- (MDPSubscriptionConfigurationBasicInfoModel*)primitiveSubscriptionConfigurationBasicInfoThumbnailImage;
- (void)setPrimitiveSubscriptionConfigurationBasicInfoThumbnailImage:(MDPSubscriptionConfigurationBasicInfoModel*)value;

- (MDPSubscriptionConfigurationBasicInfoModel*)primitiveSubscriptionConfigurationBasicInfoTitle;
- (void)setPrimitiveSubscriptionConfigurationBasicInfoTitle:(MDPSubscriptionConfigurationBasicInfoModel*)value;

- (MDPSubscriptionConfigurationModel*)primitiveSubscriptionConfigurationDescriptionSubscriptionConfiguration;
- (void)setPrimitiveSubscriptionConfigurationDescriptionSubscriptionConfiguration:(MDPSubscriptionConfigurationModel*)value;

- (MDPSubscriptionConfigurationModel*)primitiveSubscriptionConfigurationImage;
- (void)setPrimitiveSubscriptionConfigurationImage:(MDPSubscriptionConfigurationModel*)value;

- (MDPSubscriptionConfigurationModel*)primitiveSubscriptionConfigurationThumbnailImage;
- (void)setPrimitiveSubscriptionConfigurationThumbnailImage:(MDPSubscriptionConfigurationModel*)value;

- (MDPSubscriptionConfigurationModel*)primitiveSubscriptionConfigurationTitle;
- (void)setPrimitiveSubscriptionConfigurationTitle:(MDPSubscriptionConfigurationModel*)value;

- (MDPSubscriptionConfigurationTypeModel*)primitiveSubscriptionConfigurationTypeName;
- (void)setPrimitiveSubscriptionConfigurationTypeName:(MDPSubscriptionConfigurationTypeModel*)value;

- (NSMutableSet*)primitiveTanInfoName;
- (void)setPrimitiveTanInfoName:(NSMutableSet*)value;

- (NSMutableSet*)primitiveVirtualGoodResultsVirtualGood;
- (void)setPrimitiveVirtualGoodResultsVirtualGood:(NSMutableSet*)value;

- (NSMutableSet*)primitiveVirtualGoodTypeDescriptionVirtualGoodType;
- (void)setPrimitiveVirtualGoodTypeDescriptionVirtualGoodType:(NSMutableSet*)value;

- (NSMutableSet*)primitiveVirtualGoodUrl;
- (void)setPrimitiveVirtualGoodUrl:(NSMutableSet*)value;

@end
