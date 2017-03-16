//
//  _MDPFanVirtualGoodModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanVirtualGoodModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanVirtualGoodModelAttributes {
	__unsafe_unretained NSString *adquisitionDate;
	__unsafe_unretained NSString *canBeGiven;
	__unsafe_unretained NSString *canBeUsedInAvatar;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *idVirtualGood;
	__unsafe_unretained NSString *idVirtualGoodSubType;
	__unsafe_unretained NSString *idVirtualGoodType;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *timesOwned;
} MDPFanVirtualGoodModelAttributes;

extern const struct MDPFanVirtualGoodModelRelationships {
	__unsafe_unretained NSString *descriptionFanVirtualGood;
	__unsafe_unretained NSString *pagedFanVirtualGoodsResults;
	__unsafe_unretained NSString *url;
} MDPFanVirtualGoodModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPPagedFanVirtualGoodsModel;
@class MDPLocaleDescriptionModel;

@interface _MDPFanVirtualGoodModel : NSManagedObject

@property (nonatomic, strong) NSDate* adquisitionDate;

//- (BOOL)validateAdquisitionDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* canBeGiven;

@property (atomic) BOOL canBeGivenValue;
- (BOOL)canBeGivenValue;
- (void)setCanBeGivenValue:(BOOL)value_;

//- (BOOL)validateCanBeGiven:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* canBeUsedInAvatar;

@property (atomic) BOOL canBeUsedInAvatarValue;
- (BOOL)canBeUsedInAvatarValue;
- (void)setCanBeUsedInAvatarValue:(BOOL)value_;

//- (BOOL)validateCanBeUsedInAvatar:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idVirtualGood;

//- (BOOL)validateIdVirtualGood:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idVirtualGoodSubType;

//- (BOOL)validateIdVirtualGoodSubType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idVirtualGoodType;

//- (BOOL)validateIdVirtualGoodType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* timesOwned;

@property (atomic) uint64_t timesOwnedValue;
- (uint64_t)timesOwnedValue;
- (void)setTimesOwnedValue:(uint64_t)value_;

//- (BOOL)validateTimesOwned:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionFanVirtualGood;

- (NSMutableSet*)descriptionFanVirtualGoodSet;

@property (nonatomic, strong) NSSet *pagedFanVirtualGoodsResults;

- (NSMutableSet*)pagedFanVirtualGoodsResultsSet;

@property (nonatomic, strong) NSSet *url;

- (NSMutableSet*)urlSet;

@end

@interface _MDPFanVirtualGoodModel (DescriptionFanVirtualGoodCoreDataGeneratedAccessors)
- (void)addDescriptionFanVirtualGood:(NSSet*)value_;
- (void)removeDescriptionFanVirtualGood:(NSSet*)value_;
- (void)addDescriptionFanVirtualGoodObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionFanVirtualGoodObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanVirtualGoodModel (PagedFanVirtualGoodsResultsCoreDataGeneratedAccessors)
- (void)addPagedFanVirtualGoodsResults:(NSSet*)value_;
- (void)removePagedFanVirtualGoodsResults:(NSSet*)value_;
- (void)addPagedFanVirtualGoodsResultsObject:(MDPPagedFanVirtualGoodsModel*)value_;
- (void)removePagedFanVirtualGoodsResultsObject:(MDPPagedFanVirtualGoodsModel*)value_;
@end

@interface _MDPFanVirtualGoodModel (UrlCoreDataGeneratedAccessors)
- (void)addUrl:(NSSet*)value_;
- (void)removeUrl:(NSSet*)value_;
- (void)addUrlObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeUrlObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanVirtualGoodModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveAdquisitionDate;
- (void)setPrimitiveAdquisitionDate:(NSDate*)value;

- (NSNumber*)primitiveCanBeGiven;
- (void)setPrimitiveCanBeGiven:(NSNumber*)value;

- (BOOL)primitiveCanBeGivenValue;
- (void)setPrimitiveCanBeGivenValue:(BOOL)value_;

- (NSNumber*)primitiveCanBeUsedInAvatar;
- (void)setPrimitiveCanBeUsedInAvatar:(NSNumber*)value;

- (BOOL)primitiveCanBeUsedInAvatarValue;
- (void)setPrimitiveCanBeUsedInAvatarValue:(BOOL)value_;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveIdVirtualGood;
- (void)setPrimitiveIdVirtualGood:(NSString*)value;

- (NSString*)primitiveIdVirtualGoodSubType;
- (void)setPrimitiveIdVirtualGoodSubType:(NSString*)value;

- (NSString*)primitiveIdVirtualGoodType;
- (void)setPrimitiveIdVirtualGoodType:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSNumber*)primitiveTimesOwned;
- (void)setPrimitiveTimesOwned:(NSNumber*)value;

- (uint64_t)primitiveTimesOwnedValue;
- (void)setPrimitiveTimesOwnedValue:(uint64_t)value_;

- (NSMutableSet*)primitiveDescriptionFanVirtualGood;
- (void)setPrimitiveDescriptionFanVirtualGood:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedFanVirtualGoodsResults;
- (void)setPrimitivePagedFanVirtualGoodsResults:(NSMutableSet*)value;

- (NSMutableSet*)primitiveUrl;
- (void)setPrimitiveUrl:(NSMutableSet*)value;

@end
