//
//  _MDPSubscriptionConfigurationBasicInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSubscriptionConfigurationBasicInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSubscriptionConfigurationBasicInfoModelAttributes {
	__unsafe_unretained NSString *expirationType;
	__unsafe_unretained NSString *fixedExpirationDate;
	__unsafe_unretained NSString *highlight;
	__unsafe_unretained NSString *highlightInCategory;
	__unsafe_unretained NSString *idSubscription;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *pack;
	__unsafe_unretained NSString *rangeExpirationMinutes;
	__unsafe_unretained NSString *relatedChildrenSubscriptions;
	__unsafe_unretained NSString *relatedParentsSubscriptions;
	__unsafe_unretained NSString *relatedSubscriptions;
	__unsafe_unretained NSString *renewable;
	__unsafe_unretained NSString *type;
	__unsafe_unretained NSString *videosAssociated;
} MDPSubscriptionConfigurationBasicInfoModelAttributes;

extern const struct MDPSubscriptionConfigurationBasicInfoModelRelationships {
	__unsafe_unretained NSString *descriptionSubscriptionConfigurationBasicInfo;
	__unsafe_unretained NSString *image;
	__unsafe_unretained NSString *pagedSubscriptionConfigurationResults;
	__unsafe_unretained NSString *price;
	__unsafe_unretained NSString *thumbnailImage;
	__unsafe_unretained NSString *title;
} MDPSubscriptionConfigurationBasicInfoModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPPagedSubscriptionConfigurationModel;
@class MDPProductPriceModel;
@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;

@interface _MDPSubscriptionConfigurationBasicInfoModel : NSManagedObject

@property (nonatomic, strong) NSNumber* expirationType;

@property (atomic) uint16_t expirationTypeValue;
- (uint16_t)expirationTypeValue;
- (void)setExpirationTypeValue:(uint16_t)value_;

//- (BOOL)validateExpirationType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* fixedExpirationDate;

//- (BOOL)validateFixedExpirationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* highlight;

@property (atomic) BOOL highlightValue;
- (BOOL)highlightValue;
- (void)setHighlightValue:(BOOL)value_;

//- (BOOL)validateHighlight:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* highlightInCategory;

@property (atomic) BOOL highlightInCategoryValue;
- (BOOL)highlightInCategoryValue;
- (void)setHighlightInCategoryValue:(BOOL)value_;

//- (BOOL)validateHighlightInCategory:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubscription;

//- (BOOL)validateIdSubscription:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pack;

@property (atomic) BOOL packValue;
- (BOOL)packValue;
- (void)setPackValue:(BOOL)value_;

//- (BOOL)validatePack:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* rangeExpirationMinutes;

@property (atomic) int64_t rangeExpirationMinutesValue;
- (int64_t)rangeExpirationMinutesValue;
- (void)setRangeExpirationMinutesValue:(int64_t)value_;

//- (BOOL)validateRangeExpirationMinutes:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* relatedChildrenSubscriptions;

//- (BOOL)validateRelatedChildrenSubscriptions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* relatedParentsSubscriptions;

//- (BOOL)validateRelatedParentsSubscriptions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* relatedSubscriptions;

//- (BOOL)validateRelatedSubscriptions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* renewable;

@property (atomic) BOOL renewableValue;
- (BOOL)renewableValue;
- (void)setRenewableValue:(BOOL)value_;

//- (BOOL)validateRenewable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* type;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* videosAssociated;

@property (atomic) int64_t videosAssociatedValue;
- (int64_t)videosAssociatedValue;
- (void)setVideosAssociatedValue:(int64_t)value_;

//- (BOOL)validateVideosAssociated:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionSubscriptionConfigurationBasicInfo;

- (NSMutableSet*)descriptionSubscriptionConfigurationBasicInfoSet;

@property (nonatomic, strong) NSSet *image;

- (NSMutableSet*)imageSet;

@property (nonatomic, strong) MDPPagedSubscriptionConfigurationModel *pagedSubscriptionConfigurationResults;

//- (BOOL)validatePagedSubscriptionConfigurationResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *price;

- (NSMutableSet*)priceSet;

@property (nonatomic, strong) NSSet *thumbnailImage;

- (NSMutableSet*)thumbnailImageSet;

@property (nonatomic, strong) NSSet *title;

- (NSMutableSet*)titleSet;

@end

@interface _MDPSubscriptionConfigurationBasicInfoModel (DescriptionSubscriptionConfigurationBasicInfoCoreDataGeneratedAccessors)
- (void)addDescriptionSubscriptionConfigurationBasicInfo:(NSSet*)value_;
- (void)removeDescriptionSubscriptionConfigurationBasicInfo:(NSSet*)value_;
- (void)addDescriptionSubscriptionConfigurationBasicInfoObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionSubscriptionConfigurationBasicInfoObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationBasicInfoModel (ImageCoreDataGeneratedAccessors)
- (void)addImage:(NSSet*)value_;
- (void)removeImage:(NSSet*)value_;
- (void)addImageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeImageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationBasicInfoModel (PriceCoreDataGeneratedAccessors)
- (void)addPrice:(NSSet*)value_;
- (void)removePrice:(NSSet*)value_;
- (void)addPriceObject:(MDPProductPriceModel*)value_;
- (void)removePriceObject:(MDPProductPriceModel*)value_;
@end

@interface _MDPSubscriptionConfigurationBasicInfoModel (ThumbnailImageCoreDataGeneratedAccessors)
- (void)addThumbnailImage:(NSSet*)value_;
- (void)removeThumbnailImage:(NSSet*)value_;
- (void)addThumbnailImageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeThumbnailImageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationBasicInfoModel (TitleCoreDataGeneratedAccessors)
- (void)addTitle:(NSSet*)value_;
- (void)removeTitle:(NSSet*)value_;
- (void)addTitleObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeTitleObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPSubscriptionConfigurationBasicInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveExpirationType;
- (void)setPrimitiveExpirationType:(NSNumber*)value;

- (uint16_t)primitiveExpirationTypeValue;
- (void)setPrimitiveExpirationTypeValue:(uint16_t)value_;

- (NSDate*)primitiveFixedExpirationDate;
- (void)setPrimitiveFixedExpirationDate:(NSDate*)value;

- (NSNumber*)primitiveHighlight;
- (void)setPrimitiveHighlight:(NSNumber*)value;

- (BOOL)primitiveHighlightValue;
- (void)setPrimitiveHighlightValue:(BOOL)value_;

- (NSNumber*)primitiveHighlightInCategory;
- (void)setPrimitiveHighlightInCategory:(NSNumber*)value;

- (BOOL)primitiveHighlightInCategoryValue;
- (void)setPrimitiveHighlightInCategoryValue:(BOOL)value_;

- (NSString*)primitiveIdSubscription;
- (void)setPrimitiveIdSubscription:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitivePack;
- (void)setPrimitivePack:(NSNumber*)value;

- (BOOL)primitivePackValue;
- (void)setPrimitivePackValue:(BOOL)value_;

- (NSNumber*)primitiveRangeExpirationMinutes;
- (void)setPrimitiveRangeExpirationMinutes:(NSNumber*)value;

- (int64_t)primitiveRangeExpirationMinutesValue;
- (void)setPrimitiveRangeExpirationMinutesValue:(int64_t)value_;

- (NSData*)primitiveRelatedChildrenSubscriptions;
- (void)setPrimitiveRelatedChildrenSubscriptions:(NSData*)value;

- (NSData*)primitiveRelatedParentsSubscriptions;
- (void)setPrimitiveRelatedParentsSubscriptions:(NSData*)value;

- (NSData*)primitiveRelatedSubscriptions;
- (void)setPrimitiveRelatedSubscriptions:(NSData*)value;

- (NSNumber*)primitiveRenewable;
- (void)setPrimitiveRenewable:(NSNumber*)value;

- (BOOL)primitiveRenewableValue;
- (void)setPrimitiveRenewableValue:(BOOL)value_;

- (NSString*)primitiveType;
- (void)setPrimitiveType:(NSString*)value;

- (NSNumber*)primitiveVideosAssociated;
- (void)setPrimitiveVideosAssociated:(NSNumber*)value;

- (int64_t)primitiveVideosAssociatedValue;
- (void)setPrimitiveVideosAssociatedValue:(int64_t)value_;

- (NSMutableSet*)primitiveDescriptionSubscriptionConfigurationBasicInfo;
- (void)setPrimitiveDescriptionSubscriptionConfigurationBasicInfo:(NSMutableSet*)value;

- (NSMutableSet*)primitiveImage;
- (void)setPrimitiveImage:(NSMutableSet*)value;

- (MDPPagedSubscriptionConfigurationModel*)primitivePagedSubscriptionConfigurationResults;
- (void)setPrimitivePagedSubscriptionConfigurationResults:(MDPPagedSubscriptionConfigurationModel*)value;

- (NSMutableSet*)primitivePrice;
- (void)setPrimitivePrice:(NSMutableSet*)value;

- (NSMutableSet*)primitiveThumbnailImage;
- (void)setPrimitiveThumbnailImage:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTitle;
- (void)setPrimitiveTitle:(NSMutableSet*)value;

@end
