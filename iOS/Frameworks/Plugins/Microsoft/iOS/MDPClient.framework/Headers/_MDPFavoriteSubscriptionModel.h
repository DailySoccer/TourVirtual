//
//  _MDPFavoriteSubscriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFavoriteSubscriptionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFavoriteSubscriptionModelAttributes {
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *idSubscription;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *pack;
	__unsafe_unretained NSString *relatedChildrenSubscriptions;
	__unsafe_unretained NSString *relatedParentsSubscriptions;
	__unsafe_unretained NSString *type;
	__unsafe_unretained NSString *videosAssociated;
} MDPFavoriteSubscriptionModelAttributes;

extern const struct MDPFavoriteSubscriptionModelRelationships {
	__unsafe_unretained NSString *favoriteSubscriptionDescription;
	__unsafe_unretained NSString *image;
	__unsafe_unretained NSString *pagedFavoriteSubscriptionResults;
	__unsafe_unretained NSString *price;
	__unsafe_unretained NSString *thumbnailImage;
	__unsafe_unretained NSString *title;
} MDPFavoriteSubscriptionModelRelationships;

extern const struct MDPFavoriteSubscriptionModelUserInfo {
	__unsafe_unretained NSString *mappedKeyName;
} MDPFavoriteSubscriptionModelUserInfo;

@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;
@class MDPPagedFavoriteSubscriptionModel;
@class MDPProductPriceModel;
@class MDPLocaleDescriptionModel;
@class MDPLocaleDescriptionModel;

@interface _MDPFavoriteSubscriptionModel : NSManagedObject

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSData* relatedChildrenSubscriptions;

//- (BOOL)validateRelatedChildrenSubscriptions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* relatedParentsSubscriptions;

//- (BOOL)validateRelatedParentsSubscriptions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* type;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* videosAssociated;

@property (atomic) int64_t videosAssociatedValue;
- (int64_t)videosAssociatedValue;
- (void)setVideosAssociatedValue:(int64_t)value_;

//- (BOOL)validateVideosAssociated:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *favoriteSubscriptionDescription;

- (NSMutableSet*)favoriteSubscriptionDescriptionSet;

@property (nonatomic, strong) NSSet *image;

- (NSMutableSet*)imageSet;

@property (nonatomic, strong) NSSet *pagedFavoriteSubscriptionResults;

- (NSMutableSet*)pagedFavoriteSubscriptionResultsSet;

@property (nonatomic, strong) NSSet *price;

- (NSMutableSet*)priceSet;

@property (nonatomic, strong) NSSet *thumbnailImage;

- (NSMutableSet*)thumbnailImageSet;

@property (nonatomic, strong) NSSet *title;

- (NSMutableSet*)titleSet;

@end

@interface _MDPFavoriteSubscriptionModel (FavoriteSubscriptionDescriptionCoreDataGeneratedAccessors)
- (void)addFavoriteSubscriptionDescription:(NSSet*)value_;
- (void)removeFavoriteSubscriptionDescription:(NSSet*)value_;
- (void)addFavoriteSubscriptionDescriptionObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeFavoriteSubscriptionDescriptionObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFavoriteSubscriptionModel (ImageCoreDataGeneratedAccessors)
- (void)addImage:(NSSet*)value_;
- (void)removeImage:(NSSet*)value_;
- (void)addImageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeImageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFavoriteSubscriptionModel (PagedFavoriteSubscriptionResultsCoreDataGeneratedAccessors)
- (void)addPagedFavoriteSubscriptionResults:(NSSet*)value_;
- (void)removePagedFavoriteSubscriptionResults:(NSSet*)value_;
- (void)addPagedFavoriteSubscriptionResultsObject:(MDPPagedFavoriteSubscriptionModel*)value_;
- (void)removePagedFavoriteSubscriptionResultsObject:(MDPPagedFavoriteSubscriptionModel*)value_;
@end

@interface _MDPFavoriteSubscriptionModel (PriceCoreDataGeneratedAccessors)
- (void)addPrice:(NSSet*)value_;
- (void)removePrice:(NSSet*)value_;
- (void)addPriceObject:(MDPProductPriceModel*)value_;
- (void)removePriceObject:(MDPProductPriceModel*)value_;
@end

@interface _MDPFavoriteSubscriptionModel (ThumbnailImageCoreDataGeneratedAccessors)
- (void)addThumbnailImage:(NSSet*)value_;
- (void)removeThumbnailImage:(NSSet*)value_;
- (void)addThumbnailImageObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeThumbnailImageObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFavoriteSubscriptionModel (TitleCoreDataGeneratedAccessors)
- (void)addTitle:(NSSet*)value_;
- (void)removeTitle:(NSSet*)value_;
- (void)addTitleObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeTitleObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPFavoriteSubscriptionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

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

- (NSData*)primitiveRelatedChildrenSubscriptions;
- (void)setPrimitiveRelatedChildrenSubscriptions:(NSData*)value;

- (NSData*)primitiveRelatedParentsSubscriptions;
- (void)setPrimitiveRelatedParentsSubscriptions:(NSData*)value;

- (NSString*)primitiveType;
- (void)setPrimitiveType:(NSString*)value;

- (NSNumber*)primitiveVideosAssociated;
- (void)setPrimitiveVideosAssociated:(NSNumber*)value;

- (int64_t)primitiveVideosAssociatedValue;
- (void)setPrimitiveVideosAssociatedValue:(int64_t)value_;

- (NSMutableSet*)primitiveFavoriteSubscriptionDescription;
- (void)setPrimitiveFavoriteSubscriptionDescription:(NSMutableSet*)value;

- (NSMutableSet*)primitiveImage;
- (void)setPrimitiveImage:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedFavoriteSubscriptionResults;
- (void)setPrimitivePagedFavoriteSubscriptionResults:(NSMutableSet*)value;

- (NSMutableSet*)primitivePrice;
- (void)setPrimitivePrice:(NSMutableSet*)value;

- (NSMutableSet*)primitiveThumbnailImage;
- (void)setPrimitiveThumbnailImage:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTitle;
- (void)setPrimitiveTitle:(NSMutableSet*)value;

@end
