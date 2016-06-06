//
//  _MDPSplashModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPSplashModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPSplashModelAttributes {
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idSplash;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *urlAsset;
} MDPSplashModelAttributes;

@interface _MDPSplashModel : NSManagedObject

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSplash;

//- (BOOL)validateIdSplash:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlAsset;

//- (BOOL)validateUrlAsset:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPSplashModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdSplash;
- (void)setPrimitiveIdSplash:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveUrlAsset;
- (void)setPrimitiveUrlAsset:(NSString*)value;

@end
