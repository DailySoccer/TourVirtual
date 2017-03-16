//
//  _MDPFavoriteContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFavoriteContentModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFavoriteContentModelAttributes {
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *favoriteContentDescription;
	__unsafe_unretained NSString *favoriteContentTitle;
	__unsafe_unretained NSString *favoriteContentType;
	__unsafe_unretained NSString *idContent;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPFavoriteContentModelAttributes;

extern const struct MDPFavoriteContentModelRelationships {
	__unsafe_unretained NSString *assets;
	__unsafe_unretained NSString *pagedFavoriteContent;
} MDPFavoriteContentModelRelationships;

@class MDPAssetModel;
@class MDPPagedFavoriteContentModel;

@interface _MDPFavoriteContentModel : NSManagedObject

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* favoriteContentDescription;

//- (BOOL)validateFavoriteContentDescription:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* favoriteContentTitle;

//- (BOOL)validateFavoriteContentTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* favoriteContentType;

//- (BOOL)validateFavoriteContentType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idContent;

//- (BOOL)validateIdContent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *assets;

- (NSMutableSet*)assetsSet;

@property (nonatomic, strong) MDPPagedFavoriteContentModel *pagedFavoriteContent;

//- (BOOL)validatePagedFavoriteContent:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFavoriteContentModel (AssetsCoreDataGeneratedAccessors)
- (void)addAssets:(NSSet*)value_;
- (void)removeAssets:(NSSet*)value_;
- (void)addAssetsObject:(MDPAssetModel*)value_;
- (void)removeAssetsObject:(MDPAssetModel*)value_;
@end

@interface _MDPFavoriteContentModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

- (NSString*)primitiveFavoriteContentDescription;
- (void)setPrimitiveFavoriteContentDescription:(NSString*)value;

- (NSString*)primitiveFavoriteContentTitle;
- (void)setPrimitiveFavoriteContentTitle:(NSString*)value;

- (NSString*)primitiveFavoriteContentType;
- (void)setPrimitiveFavoriteContentType:(NSString*)value;

- (NSString*)primitiveIdContent;
- (void)setPrimitiveIdContent:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSMutableSet*)primitiveAssets;
- (void)setPrimitiveAssets:(NSMutableSet*)value;

- (MDPPagedFavoriteContentModel*)primitivePagedFavoriteContent;
- (void)setPrimitivePagedFavoriteContent:(MDPPagedFavoriteContentModel*)value;

@end
