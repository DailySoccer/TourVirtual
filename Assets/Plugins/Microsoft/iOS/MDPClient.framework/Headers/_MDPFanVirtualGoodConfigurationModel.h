//
//  _MDPFanVirtualGoodConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanVirtualGoodConfigurationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanVirtualGoodConfigurationModelAttributes {
	__unsafe_unretained NSString *adquisitionDate;
	__unsafe_unretained NSString *canBeGiven;
	__unsafe_unretained NSString *canBeUsed;
	__unsafe_unretained NSString *canBeUsedInAvatar;
	__unsafe_unretained NSString *count;
	__unsafe_unretained NSString *enabled;
	__unsafe_unretained NSString *expirationInDays;
	__unsafe_unretained NSString *highLightInCategory;
	__unsafe_unretained NSString *highlight;
	__unsafe_unretained NSString *idSubType;
	__unsafe_unretained NSString *idType;
	__unsafe_unretained NSString *idVirtualGood;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *minAge;
	__unsafe_unretained NSString *ownedByFan;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *purchasable;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *valueInPoints;
} MDPFanVirtualGoodConfigurationModelAttributes;

extern const struct MDPFanVirtualGoodConfigurationModelRelationships {
	__unsafe_unretained NSString *descriptionFanVirtualGoodConfiguration;
	__unsafe_unretained NSString *fanvirtualGoodsConfigurationRequest;
	__unsafe_unretained NSString *price;
	__unsafe_unretained NSString *url;
} MDPFanVirtualGoodConfigurationModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPFanVirtualGoodConfigurationRequestModel;
@class MDPProductPriceModel;
@class MDPLocaleDescriptionModel;

@interface _MDPFanVirtualGoodConfigurationModel : NSManagedObject

@property (nonatomic, strong) NSDate* adquisitionDate;

//- (BOOL)validateAdquisitionDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* canBeGiven;

@property (atomic) BOOL canBeGivenValue;
- (BOOL)canBeGivenValue;
- (void)setCanBeGivenValue:(BOOL)value_;

//- (BOOL)validateCanBeGiven:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* canBeUsed;

@property (atomic) BOOL canBeUsedValue;
- (BOOL)canBeUsedValue;
- (void)setCanBeUsedValue:(BOOL)value_;

//- (BOOL)validateCanBeUsed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* canBeUsedInAvatar;

@property (atomic) BOOL canBeUsedInAvatarValue;
- (BOOL)canBeUsedInAvatarValue;
- (void)setCanBeUsedInAvatarValue:(BOOL)value_;

//- (BOOL)validateCanBeUsedInAvatar:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* count;

@property (atomic) int64_t countValue;
- (int64_t)countValue;
- (void)setCountValue:(int64_t)value_;

//- (BOOL)validateCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* enabled;

@property (atomic) BOOL enabledValue;
- (BOOL)enabledValue;
- (void)setEnabledValue:(BOOL)value_;

//- (BOOL)validateEnabled:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* expirationInDays;

@property (atomic) int64_t expirationInDaysValue;
- (int64_t)expirationInDaysValue;
- (void)setExpirationInDaysValue:(int64_t)value_;

//- (BOOL)validateExpirationInDays:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* highLightInCategory;

@property (atomic) BOOL highLightInCategoryValue;
- (BOOL)highLightInCategoryValue;
- (void)setHighLightInCategoryValue:(BOOL)value_;

//- (BOOL)validateHighLightInCategory:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* highlight;

@property (atomic) BOOL highlightValue;
- (BOOL)highlightValue;
- (void)setHighlightValue:(BOOL)value_;

//- (BOOL)validateHighlight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubType;

//- (BOOL)validateIdSubType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idType;

//- (BOOL)validateIdType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idVirtualGood;

//- (BOOL)validateIdVirtualGood:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minAge;

@property (atomic) int64_t minAgeValue;
- (int64_t)minAgeValue;
- (void)setMinAgeValue:(int64_t)value_;

//- (BOOL)validateMinAge:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* ownedByFan;

@property (atomic) BOOL ownedByFanValue;
- (BOOL)ownedByFanValue;
- (void)setOwnedByFanValue:(BOOL)value_;

//- (BOOL)validateOwnedByFan:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* purchasable;

@property (atomic) BOOL purchasableValue;
- (BOOL)purchasableValue;
- (void)setPurchasableValue:(BOOL)value_;

//- (BOOL)validatePurchasable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* valueInPoints;

@property (atomic) int64_t valueInPointsValue;
- (int64_t)valueInPointsValue;
- (void)setValueInPointsValue:(int64_t)value_;

//- (BOOL)validateValueInPoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionFanVirtualGoodConfiguration;

- (NSMutableSet*)descriptionFanVirtualGoodConfigurationSet;

@property (nonatomic, strong) MDPFanVirtualGoodConfigurationRequestModel *fanvirtualGoodsConfigurationRequest;

//- (BOOL)validateFanvirtualGoodsConfigurationRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *price;

- (NSMutableSet*)priceSet;

@property (nonatomic, strong) NSSet *url;

- (NSMutableSet*)urlSet;

@end

@interface _MDPFanVirtualGoodConfigurationModel (DescriptionFanVirtualGoodConfigurationCoreDataGeneratedAccessors)
- (void)addDescriptionFanVirtualGoodConfiguration:(NSSet*)value_;
- (void)removeDescriptionFanVirtualGoodConfiguration:(NSSet*)value_;
- (void)addDescriptionFanVirtualGoodConfigurationObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionFanVirtualGoodConfigurationObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanVirtualGoodConfigurationModel (PriceCoreDataGeneratedAccessors)
- (void)addPrice:(NSSet*)value_;
- (void)removePrice:(NSSet*)value_;
- (void)addPriceObject:(MDPProductPriceModel*)value_;
- (void)removePriceObject:(MDPProductPriceModel*)value_;
@end

@interface _MDPFanVirtualGoodConfigurationModel (UrlCoreDataGeneratedAccessors)
- (void)addUrl:(NSSet*)value_;
- (void)removeUrl:(NSSet*)value_;
- (void)addUrlObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeUrlObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanVirtualGoodConfigurationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveAdquisitionDate;
- (void)setPrimitiveAdquisitionDate:(NSDate*)value;

- (NSNumber*)primitiveCanBeGiven;
- (void)setPrimitiveCanBeGiven:(NSNumber*)value;

- (BOOL)primitiveCanBeGivenValue;
- (void)setPrimitiveCanBeGivenValue:(BOOL)value_;

- (NSNumber*)primitiveCanBeUsed;
- (void)setPrimitiveCanBeUsed:(NSNumber*)value;

- (BOOL)primitiveCanBeUsedValue;
- (void)setPrimitiveCanBeUsedValue:(BOOL)value_;

- (NSNumber*)primitiveCanBeUsedInAvatar;
- (void)setPrimitiveCanBeUsedInAvatar:(NSNumber*)value;

- (BOOL)primitiveCanBeUsedInAvatarValue;
- (void)setPrimitiveCanBeUsedInAvatarValue:(BOOL)value_;

- (NSNumber*)primitiveCount;
- (void)setPrimitiveCount:(NSNumber*)value;

- (int64_t)primitiveCountValue;
- (void)setPrimitiveCountValue:(int64_t)value_;

- (NSNumber*)primitiveEnabled;
- (void)setPrimitiveEnabled:(NSNumber*)value;

- (BOOL)primitiveEnabledValue;
- (void)setPrimitiveEnabledValue:(BOOL)value_;

- (NSNumber*)primitiveExpirationInDays;
- (void)setPrimitiveExpirationInDays:(NSNumber*)value;

- (int64_t)primitiveExpirationInDaysValue;
- (void)setPrimitiveExpirationInDaysValue:(int64_t)value_;

- (NSNumber*)primitiveHighLightInCategory;
- (void)setPrimitiveHighLightInCategory:(NSNumber*)value;

- (BOOL)primitiveHighLightInCategoryValue;
- (void)setPrimitiveHighLightInCategoryValue:(BOOL)value_;

- (NSNumber*)primitiveHighlight;
- (void)setPrimitiveHighlight:(NSNumber*)value;

- (BOOL)primitiveHighlightValue;
- (void)setPrimitiveHighlightValue:(BOOL)value_;

- (NSString*)primitiveIdSubType;
- (void)setPrimitiveIdSubType:(NSString*)value;

- (NSString*)primitiveIdType;
- (void)setPrimitiveIdType:(NSString*)value;

- (NSString*)primitiveIdVirtualGood;
- (void)setPrimitiveIdVirtualGood:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMinAge;
- (void)setPrimitiveMinAge:(NSNumber*)value;

- (int64_t)primitiveMinAgeValue;
- (void)setPrimitiveMinAgeValue:(int64_t)value_;

- (NSNumber*)primitiveOwnedByFan;
- (void)setPrimitiveOwnedByFan:(NSNumber*)value;

- (BOOL)primitiveOwnedByFanValue;
- (void)setPrimitiveOwnedByFanValue:(BOOL)value_;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSNumber*)primitivePurchasable;
- (void)setPrimitivePurchasable:(NSNumber*)value;

- (BOOL)primitivePurchasableValue;
- (void)setPrimitivePurchasableValue:(BOOL)value_;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSNumber*)primitiveValueInPoints;
- (void)setPrimitiveValueInPoints:(NSNumber*)value;

- (int64_t)primitiveValueInPointsValue;
- (void)setPrimitiveValueInPointsValue:(int64_t)value_;

- (NSMutableSet*)primitiveDescriptionFanVirtualGoodConfiguration;
- (void)setPrimitiveDescriptionFanVirtualGoodConfiguration:(NSMutableSet*)value;

- (MDPFanVirtualGoodConfigurationRequestModel*)primitiveFanvirtualGoodsConfigurationRequest;
- (void)setPrimitiveFanvirtualGoodsConfigurationRequest:(MDPFanVirtualGoodConfigurationRequestModel*)value;

- (NSMutableSet*)primitivePrice;
- (void)setPrimitivePrice:(NSMutableSet*)value;

- (NSMutableSet*)primitiveUrl;
- (void)setPrimitiveUrl:(NSMutableSet*)value;

@end
