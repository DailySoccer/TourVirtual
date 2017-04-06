//
//  _MDPSubscriptionConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSubscriptionConfigurationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSubscriptionConfigurationModelAttributes {
	__unsafe_unretained NSString *allowedCountries;
	__unsafe_unretained NSString *expirationType;
	__unsafe_unretained NSString *fixedExpirationDate;
	__unsafe_unretained NSString *idSubscription;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *maxConnectedDevices;
	__unsafe_unretained NSString *pack;
	__unsafe_unretained NSString *rangeExpirationMinutes;
	__unsafe_unretained NSString *renewable;
	__unsafe_unretained NSString *subscriptionConfigurationType;
} MDPSubscriptionConfigurationModelAttributes;

extern const struct MDPSubscriptionConfigurationModelRelationships {
	__unsafe_unretained NSString *descriptionSubscriptionConfiguration;
	__unsafe_unretained NSString *image;
	__unsafe_unretained NSString *price;
	__unsafe_unretained NSString *thumbnailImage;
	__unsafe_unretained NSString *title;
} MDPSubscriptionConfigurationModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPProductPriceModel;
@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;

@interface _MDPSubscriptionConfigurationModel : NSManagedObject

@property (nonatomic, strong) NSData* allowedCountries;

//- (BOOL)validateAllowedCountries:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* expirationType;

@property (atomic) uint16_t expirationTypeValue;
- (uint16_t)expirationTypeValue;
- (void)setExpirationTypeValue:(uint16_t)value_;

//- (BOOL)validateExpirationType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* fixedExpirationDate;

//- (BOOL)validateFixedExpirationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubscription;

//- (BOOL)validateIdSubscription:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* maxConnectedDevices;

@property (atomic) int64_t maxConnectedDevicesValue;
- (int64_t)maxConnectedDevicesValue;
- (void)setMaxConnectedDevicesValue:(int64_t)value_;

//- (BOOL)validateMaxConnectedDevices:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pack;

//- (BOOL)validatePack:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* rangeExpirationMinutes;

@property (atomic) int64_t rangeExpirationMinutesValue;
- (int64_t)rangeExpirationMinutesValue;
- (void)setRangeExpirationMinutesValue:(int64_t)value_;

//- (BOOL)validateRangeExpirationMinutes:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* renewable;

@property (atomic) BOOL renewableValue;
- (BOOL)renewableValue;
- (void)setRenewableValue:(BOOL)value_;

//- (BOOL)validateRenewable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* subscriptionConfigurationType;

//- (BOOL)validateSubscriptionConfigurationType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionSubscriptionConfiguration;

- (NSMutableSet*)descriptionSubscriptionConfigurationSet;

@property (nonatomic, strong) NSSet *image;

- (NSMutableSet*)imageSet;

@property (nonatomic, strong) NSSet *price;

- (NSMutableSet*)priceSet;

@property (nonatomic, strong) NSSet *thumbnailImage;

- (NSMutableSet*)thumbnailImageSet;

@property (nonatomic, strong) NSSet *title;

- (NSMutableSet*)titleSet;

@end

@interface _MDPSubscriptionConfigurationModel (DescriptionSubscriptionConfigurationCoreDataGeneratedAccessors)
- (void)addDescriptionSubscriptionConfiguration:(NSSet*)value_;
- (void)removeDescriptionSubscriptionConfiguration:(NSSet*)value_;
- (void)addDescriptionSubscriptionConfigurationObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionSubscriptionConfigurationObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationModel (ImageCoreDataGeneratedAccessors)
- (void)addImage:(NSSet*)value_;
- (void)removeImage:(NSSet*)value_;
- (void)addImageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeImageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationModel (PriceCoreDataGeneratedAccessors)
- (void)addPrice:(NSSet*)value_;
- (void)removePrice:(NSSet*)value_;
- (void)addPriceObject:(MDPProductPriceModel*)value_;
- (void)removePriceObject:(MDPProductPriceModel*)value_;
@end

@interface _MDPSubscriptionConfigurationModel (ThumbnailImageCoreDataGeneratedAccessors)
- (void)addThumbnailImage:(NSSet*)value_;
- (void)removeThumbnailImage:(NSSet*)value_;
- (void)addThumbnailImageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeThumbnailImageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationModel (TitleCoreDataGeneratedAccessors)
- (void)addTitle:(NSSet*)value_;
- (void)removeTitle:(NSSet*)value_;
- (void)addTitleObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeTitleObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSData*)primitiveAllowedCountries;
- (void)setPrimitiveAllowedCountries:(NSData*)value;

- (NSNumber*)primitiveExpirationType;
- (void)setPrimitiveExpirationType:(NSNumber*)value;

- (uint16_t)primitiveExpirationTypeValue;
- (void)setPrimitiveExpirationTypeValue:(uint16_t)value_;

- (NSDate*)primitiveFixedExpirationDate;
- (void)setPrimitiveFixedExpirationDate:(NSDate*)value;

- (NSString*)primitiveIdSubscription;
- (void)setPrimitiveIdSubscription:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMaxConnectedDevices;
- (void)setPrimitiveMaxConnectedDevices:(NSNumber*)value;

- (int64_t)primitiveMaxConnectedDevicesValue;
- (void)setPrimitiveMaxConnectedDevicesValue:(int64_t)value_;

- (NSString*)primitivePack;
- (void)setPrimitivePack:(NSString*)value;

- (NSNumber*)primitiveRangeExpirationMinutes;
- (void)setPrimitiveRangeExpirationMinutes:(NSNumber*)value;

- (int64_t)primitiveRangeExpirationMinutesValue;
- (void)setPrimitiveRangeExpirationMinutesValue:(int64_t)value_;

- (NSNumber*)primitiveRenewable;
- (void)setPrimitiveRenewable:(NSNumber*)value;

- (BOOL)primitiveRenewableValue;
- (void)setPrimitiveRenewableValue:(BOOL)value_;

- (NSString*)primitiveSubscriptionConfigurationType;
- (void)setPrimitiveSubscriptionConfigurationType:(NSString*)value;

- (NSMutableSet*)primitiveDescriptionSubscriptionConfiguration;
- (void)setPrimitiveDescriptionSubscriptionConfiguration:(NSMutableSet*)value;

- (NSMutableSet*)primitiveImage;
- (void)setPrimitiveImage:(NSMutableSet*)value;

- (NSMutableSet*)primitivePrice;
- (void)setPrimitivePrice:(NSMutableSet*)value;

- (NSMutableSet*)primitiveThumbnailImage;
- (void)setPrimitiveThumbnailImage:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTitle;
- (void)setPrimitiveTitle:(NSMutableSet*)value;

@end
