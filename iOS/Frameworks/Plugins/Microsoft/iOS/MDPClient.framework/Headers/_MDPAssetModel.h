//
//  _MDPAssetModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAssetModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAssetModelAttributes {
	__unsafe_unretained NSString *assetUrl;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *typeAsset;
} MDPAssetModelAttributes;

extern const struct MDPAssetModelRelationships {
	__unsafe_unretained NSString *compactContentAsset;
	__unsafe_unretained NSString *contentAssets;
	__unsafe_unretained NSString *favoriteContentAsset;
	__unsafe_unretained NSString *matchEventAsset;
} MDPAssetModelRelationships;

@class MDPCompactContentModel;
@class MDPContentModel;
@class MDPFavoriteContentModel;
@class MDPMatchEventModel;

@interface _MDPAssetModel : NSManagedObject

@property (nonatomic, strong) NSString* assetUrl;

//- (BOOL)validateAssetUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* typeAsset;

@property (atomic) uint16_t typeAssetValue;
- (uint16_t)typeAssetValue;
- (void)setTypeAssetValue:(uint16_t)value_;

//- (BOOL)validateTypeAsset:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *compactContentAsset;

- (NSMutableSet*)compactContentAssetSet;

@property (nonatomic, strong) NSSet *contentAssets;

- (NSMutableSet*)contentAssetsSet;

@property (nonatomic, strong) MDPFavoriteContentModel *favoriteContentAsset;

//- (BOOL)validateFavoriteContentAsset:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchEventModel *matchEventAsset;

//- (BOOL)validateMatchEventAsset:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPAssetModel (CompactContentAssetCoreDataGeneratedAccessors)
- (void)addCompactContentAsset:(NSSet*)value_;
- (void)removeCompactContentAsset:(NSSet*)value_;
- (void)addCompactContentAssetObject:(MDPCompactContentModel*)value_;
- (void)removeCompactContentAssetObject:(MDPCompactContentModel*)value_;
@end

@interface _MDPAssetModel (ContentAssetsCoreDataGeneratedAccessors)
- (void)addContentAssets:(NSSet*)value_;
- (void)removeContentAssets:(NSSet*)value_;
- (void)addContentAssetsObject:(MDPContentModel*)value_;
- (void)removeContentAssetsObject:(MDPContentModel*)value_;
@end

@interface _MDPAssetModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAssetUrl;
- (void)setPrimitiveAssetUrl:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSNumber*)primitiveTypeAsset;
- (void)setPrimitiveTypeAsset:(NSNumber*)value;

- (uint16_t)primitiveTypeAssetValue;
- (void)setPrimitiveTypeAssetValue:(uint16_t)value_;

- (NSMutableSet*)primitiveCompactContentAsset;
- (void)setPrimitiveCompactContentAsset:(NSMutableSet*)value;

- (NSMutableSet*)primitiveContentAssets;
- (void)setPrimitiveContentAssets:(NSMutableSet*)value;

- (MDPFavoriteContentModel*)primitiveFavoriteContentAsset;
- (void)setPrimitiveFavoriteContentAsset:(MDPFavoriteContentModel*)value;

- (MDPMatchEventModel*)primitiveMatchEventAsset;
- (void)setPrimitiveMatchEventAsset:(MDPMatchEventModel*)value;

@end
