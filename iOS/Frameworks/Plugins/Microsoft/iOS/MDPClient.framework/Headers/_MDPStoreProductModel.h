//
//  _MDPStoreProductModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPStoreProductModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPStoreProductModelAttributes {
	__unsafe_unretained NSString *amount;
	__unsafe_unretained NSString *disabled;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idProduct;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *storeProductPictureUrl;
	__unsafe_unretained NSString *storeProductThumbnailUrl;
	__unsafe_unretained NSString *storeProductType;
} MDPStoreProductModelAttributes;

extern const struct MDPStoreProductModelRelationships {
	__unsafe_unretained NSString *descriptionStoreProduct;
	__unsafe_unretained NSString *items;
	__unsafe_unretained NSString *pagedStoreProductsResults;
	__unsafe_unretained NSString *title;
} MDPStoreProductModelRelationships;

@class MDPLocaleDescriptionModel;
@class MDPProductItemModel;
@class MDPPagedStoreProductsModel;
@class MDPLocaleDescriptionModel;

@interface _MDPStoreProductModel : NSManagedObject

@property (nonatomic, strong) NSDecimalNumber* amount;

//- (BOOL)validateAmount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* disabled;

@property (atomic) BOOL disabledValue;
- (BOOL)disabledValue;
- (void)setDisabledValue:(BOOL)value_;

//- (BOOL)validateDisabled:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idProduct;

//- (BOOL)validateIdProduct:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) uint64_t orderValue;
- (uint64_t)orderValue;
- (void)setOrderValue:(uint64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* storeProductPictureUrl;

//- (BOOL)validateStoreProductPictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* storeProductThumbnailUrl;

//- (BOOL)validateStoreProductThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* storeProductType;

@property (atomic) uint16_t storeProductTypeValue;
- (uint16_t)storeProductTypeValue;
- (void)setStoreProductTypeValue:(uint16_t)value_;

//- (BOOL)validateStoreProductType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *descriptionStoreProduct;

- (NSMutableSet*)descriptionStoreProductSet;

@property (nonatomic, strong) NSSet *items;

- (NSMutableSet*)itemsSet;

@property (nonatomic, strong) NSSet *pagedStoreProductsResults;

- (NSMutableSet*)pagedStoreProductsResultsSet;

@property (nonatomic, strong) NSSet *title;

- (NSMutableSet*)titleSet;

@end

@interface _MDPStoreProductModel (DescriptionStoreProductCoreDataGeneratedAccessors)
- (void)addDescriptionStoreProduct:(NSSet*)value_;
- (void)removeDescriptionStoreProduct:(NSSet*)value_;
- (void)addDescriptionStoreProductObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionStoreProductObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPStoreProductModel (ItemsCoreDataGeneratedAccessors)
- (void)addItems:(NSSet*)value_;
- (void)removeItems:(NSSet*)value_;
- (void)addItemsObject:(MDPProductItemModel*)value_;
- (void)removeItemsObject:(MDPProductItemModel*)value_;
@end

@interface _MDPStoreProductModel (PagedStoreProductsResultsCoreDataGeneratedAccessors)
- (void)addPagedStoreProductsResults:(NSSet*)value_;
- (void)removePagedStoreProductsResults:(NSSet*)value_;
- (void)addPagedStoreProductsResultsObject:(MDPPagedStoreProductsModel*)value_;
- (void)removePagedStoreProductsResultsObject:(MDPPagedStoreProductsModel*)value_;
@end

@interface _MDPStoreProductModel (TitleCoreDataGeneratedAccessors)
- (void)addTitle:(NSSet*)value_;
- (void)removeTitle:(NSSet*)value_;
- (void)addTitleObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeTitleObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPStoreProductModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDecimalNumber*)primitiveAmount;
- (void)setPrimitiveAmount:(NSDecimalNumber*)value;

- (NSNumber*)primitiveDisabled;
- (void)setPrimitiveDisabled:(NSNumber*)value;

- (BOOL)primitiveDisabledValue;
- (void)setPrimitiveDisabledValue:(BOOL)value_;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdProduct;
- (void)setPrimitiveIdProduct:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (uint64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(uint64_t)value_;

- (NSString*)primitiveStoreProductPictureUrl;
- (void)setPrimitiveStoreProductPictureUrl:(NSString*)value;

- (NSString*)primitiveStoreProductThumbnailUrl;
- (void)setPrimitiveStoreProductThumbnailUrl:(NSString*)value;

- (NSNumber*)primitiveStoreProductType;
- (void)setPrimitiveStoreProductType:(NSNumber*)value;

- (uint16_t)primitiveStoreProductTypeValue;
- (void)setPrimitiveStoreProductTypeValue:(uint16_t)value_;

- (NSMutableSet*)primitiveDescriptionStoreProduct;
- (void)setPrimitiveDescriptionStoreProduct:(NSMutableSet*)value;

- (NSMutableSet*)primitiveItems;
- (void)setPrimitiveItems:(NSMutableSet*)value;

- (NSMutableSet*)primitivePagedStoreProductsResults;
- (void)setPrimitivePagedStoreProductsResults:(NSMutableSet*)value;

- (NSMutableSet*)primitiveTitle;
- (void)setPrimitiveTitle:(NSMutableSet*)value;

@end
