//
//  _MDPFanOfferModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanOfferModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanOfferModelAttributes {
	__unsafe_unretained NSString *consumed;
	__unsafe_unretained NSString *enabled;
	__unsafe_unretained NSString *expirationDate;
	__unsafe_unretained NSString *generic;
	__unsafe_unretained NSString *idOffer;
	__unsafe_unretained NSString *idOfferType;
	__unsafe_unretained NSString *imageQrCode;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *offerType;
	__unsafe_unretained NSString *qrCode;
} MDPFanOfferModelAttributes;

extern const struct MDPFanOfferModelRelationships {
	__unsafe_unretained NSString *body;
	__unsafe_unretained NSString *imageUrl;
	__unsafe_unretained NSString *pagedOffersResults;
	__unsafe_unretained NSString *title;
} MDPFanOfferModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPPagedFanOffersModel;
@class MDPLocaleDescriptionModel;

@interface _MDPFanOfferModel : NSManagedObject

@property (nonatomic, strong) NSNumber* consumed;

@property (atomic) BOOL consumedValue;
- (BOOL)consumedValue;
- (void)setConsumedValue:(BOOL)value_;

//- (BOOL)validateConsumed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* enabled;

@property (atomic) BOOL enabledValue;
- (BOOL)enabledValue;
- (void)setEnabledValue:(BOOL)value_;

//- (BOOL)validateEnabled:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* expirationDate;

//- (BOOL)validateExpirationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* generic;

@property (atomic) BOOL genericValue;
- (BOOL)genericValue;
- (void)setGenericValue:(BOOL)value_;

//- (BOOL)validateGeneric:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idOffer;

//- (BOOL)validateIdOffer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idOfferType;

//- (BOOL)validateIdOfferType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* imageQrCode;

//- (BOOL)validateImageQrCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* offerType;

@property (atomic) int64_t offerTypeValue;
- (int64_t)offerTypeValue;
- (void)setOfferTypeValue:(int64_t)value_;

//- (BOOL)validateOfferType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* qrCode;

//- (BOOL)validateQrCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *body;

- (NSMutableSet*)bodySet;

@property (nonatomic, strong) NSSet *imageUrl;

- (NSMutableSet*)imageUrlSet;

@property (nonatomic, strong) NSSet *pagedOffersResults;

- (NSMutableSet*)pagedOffersResultsSet;

@property (nonatomic, strong) NSSet *title;

- (NSMutableSet*)titleSet;

@end

@interface _MDPFanOfferModel (BodyCoreDataGeneratedAccessors)
- (void)addBody:(NSSet*)value_;
- (void)removeBody:(NSSet*)value_;
- (void)addBodyObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeBodyObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanOfferModel (ImageUrlCoreDataGeneratedAccessors)
- (void)addImageUrl:(NSSet*)value_;
- (void)removeImageUrl:(NSSet*)value_;
- (void)addImageUrlObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeImageUrlObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanOfferModel (PagedOffersResultsCoreDataGeneratedAccessors)
- (void)addPagedOffersResults:(NSSet*)value_;
- (void)removePagedOffersResults:(NSSet*)value_;
- (void)addPagedOffersResultsObject:(MDPPagedFanOffersModel*)value_;
- (void)removePagedOffersResultsObject:(MDPPagedFanOffersModel*)value_;
@end

@interface _MDPFanOfferModel (TitleCoreDataGeneratedAccessors)
- (void)addTitle:(NSSet*)value_;
- (void)removeTitle:(NSSet*)value_;
- (void)addTitleObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeTitleObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFanOfferModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveConsumed;
- (void)setPrimitiveConsumed:(NSNumber*)value;

- (BOOL)primitiveConsumedValue;
- (void)setPrimitiveConsumedValue:(BOOL)value_;

- (NSNumber*)primitiveEnabled;
- (void)setPrimitiveEnabled:(NSNumber*)value;

- (BOOL)primitiveEnabledValue;
- (void)setPrimitiveEnabledValue:(BOOL)value_;

- (NSDate*)primitiveExpirationDate;
- (void)setPrimitiveExpirationDate:(NSDate*)value;

- (NSNumber*)primitiveGeneric;
- (void)setPrimitiveGeneric:(NSNumber*)value;

- (BOOL)primitiveGenericValue;
- (void)setPrimitiveGenericValue:(BOOL)value_;

- (NSString*)primitiveIdOffer;
- (void)setPrimitiveIdOffer:(NSString*)value;

- (NSString*)primitiveIdOfferType;
- (void)setPrimitiveIdOfferType:(NSString*)value;

- (NSData*)primitiveImageQrCode;
- (void)setPrimitiveImageQrCode:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveOfferType;
- (void)setPrimitiveOfferType:(NSNumber*)value;

- (int64_t)primitiveOfferTypeValue;
- (void)setPrimitiveOfferTypeValue:(int64_t)value_;

- (NSString*)primitiveQrCode;
- (void)setPrimitiveQrCode:(NSString*)value;

- (NSMutableSet*)primitiveBody;
- (void)setPrimitiveBody:(NSMutableSet*)value;

- (NSMutableSet*)primitiveImageUrl;
- (void)setPrimitiveImageUrl:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedOffersResults;
- (void)setPrimitivePagedOffersResults:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTitle;
- (void)setPrimitiveTitle:(NSMutableSet*)value;

@end
