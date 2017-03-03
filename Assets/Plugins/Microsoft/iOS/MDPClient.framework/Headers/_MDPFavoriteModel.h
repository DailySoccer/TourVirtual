//
//  _MDPFavoriteModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFavoriteModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFavoriteModelAttributes {
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *favoriteType;
	__unsafe_unretained NSString *idFavorite;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *sourceId;
} MDPFavoriteModelAttributes;

extern const struct MDPFavoriteModelRelationships {
	__unsafe_unretained NSString *favoritesRequest;
} MDPFavoriteModelRelationships;

@class MDPFavoriteRequestModel;

@interface _MDPFavoriteModel : NSManagedObject

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* favoriteType;

@property (atomic) int16_t favoriteTypeValue;
- (int16_t)favoriteTypeValue;
- (void)setFavoriteTypeValue:(int16_t)value_;

//- (BOOL)validateFavoriteType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idFavorite;

//- (BOOL)validateIdFavorite:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* sourceId;

//- (BOOL)validateSourceId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFavoriteRequestModel *favoritesRequest;

//- (BOOL)validateFavoritesRequest:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFavoriteModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

- (NSNumber*)primitiveFavoriteType;
- (void)setPrimitiveFavoriteType:(NSNumber*)value;

- (int16_t)primitiveFavoriteTypeValue;
- (void)setPrimitiveFavoriteTypeValue:(int16_t)value_;

- (NSString*)primitiveIdFavorite;
- (void)setPrimitiveIdFavorite:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveSourceId;
- (void)setPrimitiveSourceId:(NSString*)value;

- (MDPFavoriteRequestModel*)primitiveFavoritesRequest;
- (void)setPrimitiveFavoritesRequest:(MDPFavoriteRequestModel*)value;

@end
