//
//  _MDPGeoJsonPointModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGeoJsonPointModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGeoJsonPointModelAttributes {
	__unsafe_unretained NSString *coordinates;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *type;
} MDPGeoJsonPointModelAttributes;

extern const struct MDPGeoJsonPointModelRelationships {
	__unsafe_unretained NSString *videoLocation;
} MDPGeoJsonPointModelRelationships;

@class MDPVideoModel;

@interface _MDPGeoJsonPointModel : NSManagedObject

@property (nonatomic, strong) NSData* coordinates;

//- (BOOL)validateCoordinates:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* type;

//- (BOOL)validateType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPVideoModel *videoLocation;

//- (BOOL)validateVideoLocation:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPGeoJsonPointModel (CoreDataGeneratedPrimitiveAccessors)

- (NSData*)primitiveCoordinates;
- (void)setPrimitiveCoordinates:(NSData*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveType;
- (void)setPrimitiveType:(NSString*)value;

- (MDPVideoModel*)primitiveVideoLocation;
- (void)setPrimitiveVideoLocation:(MDPVideoModel*)value;

@end
